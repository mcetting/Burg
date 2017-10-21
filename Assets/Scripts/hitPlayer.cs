using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitPlayer : MonoBehaviour {
    public GameObject player;
	public int fuck_your_rectum;
    void OnTriggerEnter2D(Collider2D col)
    {
		if (col.transform.tag == "bound") {
			Destroy (this.gameObject);
		}
		if (col.transform.tag == "Player"&&col.gameObject!=player)
        {
            col.GetComponent<Rigidbody2D>().AddForce(transform.up*5f, ForceMode2D.Impulse);
			if(!col.GetComponent<player>().isDodging || (col.GetComponent<player>().isDodging && fuck_your_rectum == 2))
				col.GetComponent<player>().hp -= fuck_your_rectum;
            Destroy(this.gameObject);
        }else if (col.transform.tag == "shield")
        {
			if(col.transform.parent.GetComponent<followPlayer>().player != player)
	            Destroy(gameObject);
        }
    }
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
