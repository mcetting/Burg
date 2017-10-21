using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class player : MonoBehaviour {
    public Sprite finalForm;
    public Sprite finalAttack;
    int burgMeter;

    bool ActivatedPushBack;
    public bool blowBack;
    public GameObject deadme1;
    public GameObject deadme2;
    public GameObject ren;
    public GameObject ren1;
    public GameObject ren2;
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
    int spriteIndex;
    bool activated = false;
    public bool formEnabled = false;
    Sprite Og;
    // Use this for initialization
    void Start () {
        Og = ren.GetComponent<SpriteRenderer>().sprite;
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
        if(this.id == 0) {
            if(dataManager.player1index == 1) {
                Destroy(ren);
                ren = Instantiate(ren2);
                ren.GetComponent<followPlayer>().player = this.gameObject;
                runParticle = ren.transform.GetChild(2).gameObject;
                //runParticle.transform.position = new Vector3(0,0,0);
                Debug.Log("player " + this.id + "switched rens");
                spriteIndex = 1;
            }
            else {
                spriteIndex = 0;
            }
        }
        if(this.id == 1) {
            if(dataManager.player2index == 0) {
                Destroy(ren);
                ren = Instantiate(ren1);
                ren.GetComponent<followPlayer>().player = this.gameObject;
                runParticle = ren.transform.GetChild(2).gameObject;
                Debug.Log("player " + this.id + "switched rens");
                spriteIndex = 0;
            }
            else {
                spriteIndex = 1;
                //runParticle.transform.position = new Vector3(0,0,0);
            }
        }
        if(spriteIndex == 1) {
            // LUL
            moveSpeed = moveSpeed + 50;
        }
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
    public IEnumerator final()
    {
        yield return new WaitForSeconds(10f);
        formEnabled = false;
        ren.transform.GetChild(3).gameObject.SetActive(false);

    }
    public void activateFinalForm()
    {
            ren.GetComponent<SpriteRenderer>().sprite = finalForm;
            ren.GetComponent<Animator>().enabled = false;
            ren.transform.GetChild(0).gameObject.SetActive(false);
            ren.transform.GetChild(1).gameObject.SetActive(false);
            ren.transform.GetChild(2).gameObject.SetActive(false);
            Debug.Log("finalForm");
            formEnabled = true;
            //change size
            transform.localScale = new Vector3(16, 16, 16);
            ren.transform.localScale = new Vector3(16, 16, 16);
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
	void Update () {
        Debug.Log(burgMeter);
        if (burgMeter == 1&&formEnabled==false)
        {
            //final burg form
            //play the eating burger animation
            //at the end of the animation have it do the shit and start the coroutine
            ren.GetComponent<Animator>().Play("chefEatAnim");
            eating = true;
            //at the end of the animation start the shizzle
            StartCoroutine(doIt());

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
        }else if (trigger == 0 && activated == true)
        {
            activated = false;
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            //debug
            hp--;
        }
        if (hp <= 0)
        {
            ren.SetActive(false);
            if(spriteIndex == 0) {
                GameObject deadzorz = Instantiate(deadme1);
                deadzorz.transform.position = transform.position;
            }
            if(spriteIndex == 1) {
                GameObject deadzorz = Instantiate(deadme2);
                deadzorz.transform.position = transform.position;
            }
            GameManager.playerCount--;
            Destroy(this.gameObject);

        }
        float movHor = 0;
        float movVer = 0;
        float rotHor = 0;
        float rotVer = 0;
        if (eating != true)
        {
            movHor = Input.GetAxis("Horizontal" + id);
            movVer = Input.GetAxis("Vertical" + id);
            rotHor = Input.GetAxis("joyX" + id);
            rotVer = Input.GetAxis("joyY" + id);
        }

        if (movHor!=0 || movVer != 0)
        {
            if(spriteIndex == 0) {
                ren.GetComponent<Animator>().Play("chefrun");
            }
            if(spriteIndex == 1) {
                // TODO: rename the animations so we can just do chefrun + id
                ren.GetComponent<Animator>().Play("chef2run");
            }
        }
        if (rotHor != 0.0f || rotVer != 0.0f)
        {
            var angle = Mathf.Atan2(rotHor, rotVer) * Mathf.Rad2Deg;
            // Do something with the angle here.
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        if (eating != true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(movHor, movVer) * moveSpeed * Time.deltaTime;
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

	}
}
