using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepBunShieldWithParent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sortingOrder = 
			transform.parent.GetComponent<SpriteRenderer>().sortingOrder+1;
	}
}
