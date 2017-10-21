using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

	float timer;
	public GameObject DroppedItem;

	[Range(0,20)]
	public float rectumX;
	[Range(0,20)]
	public float rectumY;
	[Range(0,2)]
	public float spawnFrequency;
    //
	public Sprite[] itemSprites;
    //
	public Transform[] spawnPositions;
	GameObject parent;

	// Use this for initialization
	void Start () {
		timer = 0;
		parent = GameObject.FindGameObjectWithTag ("dropped_items");

		// start DEBUG STUFF
		
		for (int i = 0; i < 7; i++) {
			SpawnItem (i, 4);
		}
		
		//SpawnItem (5, 4);
		// end DEBUG STUFF
	}

	void SpawnItem(int id, int spawnPosIndex) {
		// make actual object
		GameObject newItem = Instantiate (DroppedItem);
		newItem.transform.SetParent(parent.transform);
		// set id to the new random id
		newItem.GetComponent<DroppedItemScript> ().id = id;
		// set the sprite according to id
		newItem.GetComponent<SpriteRenderer>().sprite = itemSprites[id];
		newItem.GetComponent<SpriteRenderer> ().sortingOrder = 3;
		// set position
		float x = spawnPositions[spawnPosIndex].position.x;
		float y = spawnPositions[spawnPosIndex].position.y;
		newItem.transform.position = new Vector3(x, y, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (timer + spawnFrequency <= Time.time) {
			// start DEBUG STUFF
			SpawnItem (Random.Range(0, itemSprites.Length), Random.Range(0,spawnPositions.Length-1));
			// end DEBUG STUFF
			//SpawnItem (Random.Range(0, itemSprites.Length), Random.Range(0,spawnPositions.Length));
			timer = Time.time;
		}
	}
}
