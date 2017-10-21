using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownItemScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //rotate
        transform.Rotate(new Vector3(0, 0, 10));
	}
}
