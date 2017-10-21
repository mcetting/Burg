using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class player : MonoBehaviour {
    //animations for each type of sprite
    public AnimatorOverrideController[] animations; 

    public Sprite[] finalForm;
    public Sprite finalAttack;
    int burgMeter;

    bool ActivatedPushBack;
    public bool blowBack;
    public GameObject[] deadmes;
    public GameObject ren;
    public GameObject[] rens;
    public GameObject runParticle;
	public int id;
    public int hp;
    public float moveSpeed;
	public List<HeldItem> heldItems;
	public int maxHeldItems;
	bool once;
    float dodge_start_time;
    public float dodge_cooldown;
    public float dodge_duration;
    public bool isDodging;
    public float dodge_speed;
    public bool isBunShielding;
    public int spriteIndex;
    public GameObject burgUI;

    bool activated = false;
    public bool formEnabled = false;
    Sprite Og;
    GameObject dodge_cd_feedback_line_obj;
    LineRenderer dodge_cd_feedback_line;
    public float dodge_cd_feedback_duration;
    public Material DodgeFeedBackMaterial;

    // Use this for initialization
    void Start () {
        burgMeter = 0;

        hp = 10;
		heldItems = new List<HeldItem>();
		once = false;
        dodge_duration = 0.15f;
        dodge_cooldown = 1.0f;
        dodge_start_time = 0;
        isDodging = false;
        dodge_speed = 1000;
        isBunShielding = false;
        if (runParticle != null)
        {
            runParticle.GetComponent<ParticleSystem>().Stop();
        }
        if(this.id >= dataManager.num_players) {
            gameObject.SetActive(false);
            burgUI.SetActive(false);
            return;
        }
        ren = Instantiate(rens[dataManager.playerSpriteIndex[this.id]]);
        ren.GetComponent<followPlayer>().player = this.gameObject;
        //set the final form
        runParticle = ren.transform.GetChild(2).gameObject;
        spriteIndex = dataManager.playerSpriteIndex[this.id];

        Og = ren.GetComponent<SpriteRenderer>().sprite;

        // faster milky character
        if (spriteIndex == 1) {
            // LUL
            moveSpeed = moveSpeed + 50;
        }
        dodge_cd_feedback_line_obj = new GameObject();
        dodge_cd_feedback_line_obj.transform.SetParent(this.gameObject.transform);
        dodge_cd_feedback_line = dodge_cd_feedback_line_obj.AddComponent<LineRenderer>();
        dodge_cd_feedback_line.enabled = false;
        dodge_cd_feedback_duration = 0.1f;
        dodge_cd_feedback_line.material = DodgeFeedBackMaterial;
        float width = 0.5f;
        dodge_cd_feedback_line.startWidth = width;
        dodge_cd_feedback_line.endWidth = width;
    }

    void FixedUpdate()
    {
        if(Time.time > dodge_start_time + dodge_duration) {
            isDodging = false;
        }
		if (Input.GetButton ("leftBumper" + id)) {
			if (!once) {
				once = true;
                if(Time.time > dodge_start_time + dodge_duration + dodge_cooldown) {
                    dodge_start_time = Time.time;
                    isDodging = true;
                }
				//dodge ();
			}
		} else {
			once = false;
		}
    }
    //------------------------------------------------------------------
    //code for final form transformation
    public IEnumerator final()
    {
        yield return new WaitForSeconds(10f);
        //deactivate timestop if your form is enabled and your spriteIndex 2
        if (spriteIndex == 2 && formEnabled == true)
        {
            useItem.timeStop = false;
        }
        formEnabled = false;
        ren.transform.GetChild(3).gameObject.SetActive(false);
        transform.localScale = new Vector3(8, 8, 8);
        ren.transform.localScale = new Vector3(8, 8, 8);
        ren.GetComponent<SpriteRenderer>().sprite = Og;
        burgMeter = 0;
        ren.transform.GetChild(0).gameObject.SetActive(true);
        ren.transform.GetChild(1).gameObject.SetActive(true);
        ren.transform.GetChild(2).gameObject.SetActive(true);
        ren.GetComponent<Animator>().enabled = true;


    }
    //activates the final form and sets the boolean formEnabled to true
    public void activateFinalForm()
    {
        Debug.Log(spriteIndex);
        ren.GetComponent<SpriteRenderer>().sprite = finalForm[spriteIndex];
        ren.GetComponent<Animator>().enabled = false;
        ren.transform.GetChild(0).gameObject.SetActive(false);
        ren.transform.GetChild(1).gameObject.SetActive(false);
        ren.transform.GetChild(2).gameObject.SetActive(false);
        Debug.Log("finalForm");
        formEnabled = true;
        //change size
        if (spriteIndex == 0)
        {
            transform.localScale = new Vector3(16, 16, 16);
            ren.transform.localScale = new Vector3(16, 16, 16);
        }else if (spriteIndex == 2)
        {
            transform.localScale = new Vector3(8, 8, 8);
            ren.transform.localScale = new Vector3(8, 8, 8);
        }

        StartCoroutine(final());
    }
    // Update is called once per frame
    public IEnumerator doIt()
    {
        yield return new WaitForSeconds(2f);
        activateFinalForm();
        ren.transform.GetChild(3).gameObject.SetActive(true);
        eating = false;
    }
    bool eating = false;
    //---------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        Debug.Log(burgMeter);
        if (burgMeter == 1 && formEnabled == false)
        {
            //final burg form
            //play the eating burger animation
            //at the end of the animation have it do the shit and start the coroutine
            //ren.GetComponent<Animator>().Play("chefEatAnim");
            if (spriteIndex == 0)
            {
                Debug.Log("play anim");
                ren.GetComponent<Animator>().Play("chefEatAnim");
                eating = true;
                //at the end of the animation start the shizzle
                StartCoroutine(doIt());
            }else if (spriteIndex == 2)
            {
                Debug.Log("play anim");
                ren.GetComponent<Animator>().Play("chefEat3");
                eating = true;
                StartCoroutine(doIt());
                //at the end of the animation start the shizzle
            }


        }
        float trigger = Input.GetAxis("Right_Trigger" + id);
        if (trigger >= 0.1f && activated == false)
        {

            activated = true;
            //eat the burg

            //check for full invenentory
            if (heldItems.Count == 7)
            {
                Debug.Log("Eat the burg");
                burgMeter++;
                //eat the burg
                heldItems.Clear();
            }
        }
        else if (trigger == 0 && activated == true)
        {
            activated = false;
        }

        //end of finalform script
        if (Input.GetKeyDown(KeyCode.V))
        {
            //debug
            hp--;
        }
        if (hp <= 0)
        {
            ren.SetActive(false);
            GameObject deadzorz = Instantiate(deadmes[dataManager.playerSpriteIndex[this.id]]);
            deadzorz.transform.position = transform.position;
            GameManager.playerCount--;
            Destroy(this.gameObject);

        }
        float movHor=0;
        float movVer=0;
        float rotHor=0;
        float rotVer=0;
        if (eating == false)
        {
            movHor = Input.GetAxis("Horizontal" + id);
            movVer = Input.GetAxis("Vertical" + id);
            rotHor = Input.GetAxis("joyX" + id);
            rotVer = Input.GetAxis("joyY" + id);
        }

        if (movHor!=0 || movVer != 0)
        {
            // TODO: rename the animations so we can just do chefrun + id
            if(spriteIndex == 0) {
                ren.GetComponent<Animator>().Play("chefrun");
            }
            if(spriteIndex == 1) {
                ren.GetComponent<Animator>().Play("chef2run");
            }
            if (spriteIndex == 2)
            {
                ren.GetComponent<Animator>().Play("chefRunAnim3");
            }
        }
        if (rotHor != 0.0f || rotVer != 0.0f)
        {
            var angle = Mathf.Atan2(rotHor, rotVer) * Mathf.Rad2Deg;
            // Do something with the angle here.
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        if (eating == false)
        {
            if (useItem.timeStop==true)
            {
                if (spriteIndex == 2 && formEnabled == true)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(movHor, movVer) * moveSpeed * Time.deltaTime;
                }
            }else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(movHor, movVer) * moveSpeed * Time.deltaTime;
            }

            if (isDodging && Time.time <= dodge_start_time + dodge_duration)
            {
                ren.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
                GetComponent<Rigidbody2D>().AddForce((new Vector3(movHor, movVer, 0)) * dodge_speed, ForceMode2D.Force);
                if (runParticle != null)
                {
                    runParticle.GetComponent<ParticleSystem>().Play();
                }
            }
            else
            {
                ren.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                if (runParticle != null)
                {
                    runParticle.GetComponent<ParticleSystem>().Stop();
                }
            }
        }
        if(!isDodging && Time.time > dodge_start_time + dodge_duration + dodge_cooldown) {
            dodge_cd_feedback_line.enabled = true;
        }
        if(isDodging || Time.time > dodge_start_time + dodge_duration + dodge_cooldown + dodge_cd_feedback_duration) {
            dodge_cd_feedback_line.enabled = false;
        }
        dodge_cd_feedback_line.SetPosition(0, transform.position + new Vector3(-1, -1.33f, 0));
        dodge_cd_feedback_line.SetPosition(1, transform.position + new Vector3(0.7f, -1.33f, 0));
        dodge_cd_feedback_line.sortingOrder = 55;
	}
}
