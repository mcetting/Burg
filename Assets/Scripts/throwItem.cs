using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwItem : MonoBehaviour {
    [SerializeField]
    private GameObject throwable;
    [SerializeField]
    private GameObject playerObj;
	private player player;
    [SerializeField]
    private GameObject itemSpawnerObj;
	private ItemSpawner itemSpawner;
    [Range(0,100)]
    public float speed;

    bool activated;
    float timer;
    float wait = .5f;

    // Use this for initialization
    void Start () {
        activated = false;
		player = playerObj.GetComponent<player> ();
		itemSpawner = itemSpawnerObj.GetComponent<ItemSpawner> ();
		
	}
	private void throwThatShit()
    {
		if (player.heldItems.Count != 0)
        {
            GetComponent<AudioSource>().Play();
			// set position of burg to player pos
            GameObject rootBurg = new GameObject();
            rootBurg.transform.position = transform.position;
			// set rotation of burg to player rot
			rootBurg.transform.rotation = new Quaternion(0, 0, transform.rotation.z, transform.rotation.w);
			rootBurg.transform.Rotate(new Vector3(0, 0, 180));

			for(int i = 0; i < player.heldItems.Count; i++) {
				// make object
				GameObject cloneThrowable = Instantiate(throwable);
				cloneThrowable.GetComponent<hitPlayer>().player = this.gameObject;
				if (player.heldItems.Count == player.maxHeldItems) {
					cloneThrowable.GetComponent<hitPlayer> ().fuck_your_rectum = 2;
				} else {
					cloneThrowable.GetComponent<hitPlayer> ().fuck_your_rectum = 1;
				}
				cloneThrowable.transform.SetParent (rootBurg.transform);
				// set sprite of throwable to damage of held item
				cloneThrowable.GetComponentInChildren<SpriteRenderer>().sprite = itemSpawner.itemSprites[player.heldItems[i].id];
				cloneThrowable.transform.position = rootBurg.transform.position;
				cloneThrowable.transform.rotation = rootBurg.transform.rotation;
			}

			// no more held items when thrown
			player.heldItems.Clear();
        }

    }

	// Update is called once per frame
	void Update () {

        if (timer + wait <= Time.time)
        {
            activated = false;
        }
		float trigger = Input.GetAxis("Right_Trigger" + player.id);
        if(trigger<=-0.1f&&activated==false)
        {
            if (useItem.timeStop == false)
            {
                throwThatShit();
                activated = true;
                timer = Time.time;
            }else if (useItem.timeStop == true && GetComponent<player>().spriteIndex == 2 && GetComponent<player>().formEnabled == true)
            {
                throwThatShit();
                activated = true;
                timer = Time.time;
            }
            


        }
		//On Button Press throw item in facing right stick direction?
	}
}
