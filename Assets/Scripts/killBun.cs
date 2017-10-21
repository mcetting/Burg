using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killBun : MonoBehaviour {
    float timer;
    public GameObject myPlayer;
    float waitTime = 2f;
	// Use this for initialization
	void Start () {
        timer = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (timer + waitTime <= Time.time)
        {
            timer = Time.time;
            myPlayer.GetComponent<player>().isBunShielding = false;
            Destroy(gameObject);
        }
	}
}
