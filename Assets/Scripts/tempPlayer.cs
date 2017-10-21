using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempPlayer : MonoBehaviour {
    public int hp;
	// Use this for initialization
	void Start () {
        hp = 10;
	}
	
	// Update is called once per frame
	void Update () {
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
	}
}
