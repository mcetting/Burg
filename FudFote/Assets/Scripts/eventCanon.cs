using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventCanon : MonoBehaviour {
	public GameObject myPlayer;
	bool fuck_her_right_in_the_pussy_plz;
    bool colliding_with_bun = false;
    GameObject colliding_player;
    [Range(0,2.0f)]
    public float dist_offset;
	void OnCollisionStay2D(Collision2D col)
    {
        if(col.transform.tag == "shield") {
            colliding_player = col.gameObject;
            colliding_with_bun = true;
        }
		else if (col.transform.tag == "Player" && col.gameObject != myPlayer && !fuck_her_right_in_the_pussy_plz)
        {
            if(!col.gameObject.GetComponent<player>().isDodging && !col.gameObject.GetComponent<player>().isBunShielding)
			    col.gameObject.GetComponent<player>().hp -= 3;
			fuck_her_right_in_the_pussy_plz = true;
        }
    }
    public void removeCollider() {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
    public void kill()
    {
        Destroy(gameObject);
    }
    public void addCollider()
    {
        if (GetComponent<Collider2D>() == null)
        {
            gameObject.AddComponent<BoxCollider2D>();
            GetComponent<BoxCollider2D>().size = new Vector2(.64f, 0.0895707f);
        }

    }
	// Use this for initialization
	void Start () {
		fuck_her_right_in_the_pussy_plz = false;
	}
	
	// Update is called once per frame
	void Update () {
        /*
        float lazer_x_len = 10;
        float lazer_y_len = 1;
		if(colliding_with_bun) {
            Vector3 dist = colliding_player.transform.position - myPlayer.transform.position;
            this.transform.localScale = new Vector3(lazer_x_len / (dist.magnitude*dist_offset),
                lazer_y_len / (dist.magnitude*dist_offset), 0);
            Debug.Log("dist.mag: " + dist.magnitude);
        }
        else {
            this.transform.localScale = new Vector3(10, 1, 0);
        }
        */
	}
}
