using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healUpbb : MonoBehaviour {
    public int curId;
    List<player> players;
	// Use this for initialization
	void Start () {
		players = new List<player> ();
	}
	void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            player p = col.GetComponent<player>();
            //they hit a button
            //heal
			players.Add(p);
            Debug.Log("player " + p.id + " entered");
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
			int id_of_leaving_player = col.GetComponent<player> ().id;
			for (int i = 0; i < players.Count; i++) {
				if (players [i].id == id_of_leaving_player) {
                    Debug.Log("player " + id_of_leaving_player + " left");
					players.RemoveAt (i);
					i--;
				}
			}
        }
    }
    int index;
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < players.Count; i++) {
			// TODO: make it so pots spawn multiple and you can go piece by piece down
                // when that happens, make a once variable so this GetButton doesn't go through all items
			if (players [i].hp < 10 && Input.GetButton ("Y" + players [i].id)) {
				Debug.Log ("heal");
				index = -1;
				for(int j = 0; j < players[i].heldItems.Count; j++) {
					if (curId == players[i].heldItems[j].id) {
						index = j;
					}
				}
				if (index != -1) {
					players [i].heldItems.RemoveAt (index);
					players[i].hp += 3;
					if (players[i].hp > 10)
					{
						players[i].hp = 10;
					}
					Debug.Log(players[i].hp);
					gameObject.SetActive(false);
				}
			}
		}

    }
}
