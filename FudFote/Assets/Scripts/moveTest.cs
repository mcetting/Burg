﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().AddForce(transform.right*.001f, ForceMode2D.Impulse);
    }
    
}
