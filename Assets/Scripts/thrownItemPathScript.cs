using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thrownItemPathScript : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (useItem.timeStop == false)
        {
            transform.parent.transform.position += transform.up * speed * Time.deltaTime;
        }

	}
}
