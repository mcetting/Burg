using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedItemScript : MonoBehaviour {
	public int id;
	int damage;

	public DroppedItemScript() {
		damage = 1;
	}

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter2D(Collider2D collider) {
		// TODO: change back to tag "Player" once we get rid of tempPlayer
		player playerComp = collider.gameObject.GetComponent<player> ();
		if (playerComp != null) {

			// TODO: check if cur id is valid to be added
			bool hit = false;
			for (int i = 0; i < playerComp.heldItems.Count; i++) {
				if (playerComp.heldItems [i].id == this.id) {
					hit = true;
				}
			}
			if (hit == false) {
				playerComp.heldItems.Add (new HeldItem (this.id));
				if (playerComp.heldItems.Count == playerComp.maxHeldItems) {
                    GameManager.burgAchieved = true;
				}
			}




			/*
			HeldItem curHeldItem = playerComp.curHeldItem;
			if (curHeldItem != null) {
				int newItemId = Combinerino (playerComp.curHeldItem.id, this.id);
				// TODO: combine items
				playerComp.curHeldItem = new HeldItem (newItemId);
			} else {
				playerComp.curHeldItem = new HeldItem (this.id);
			}
			*/
		}
		Destroy (this.gameObject);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
