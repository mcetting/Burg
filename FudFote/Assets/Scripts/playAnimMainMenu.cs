using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAnimMainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Animator>().Play("fallingBurg");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
