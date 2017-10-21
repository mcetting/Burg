using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catchABurg : MonoBehaviour {
    public Sprite arrow;
    public Sprite catchBurg;
	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().sprite = arrow;
	}
	
	// Update is called once per frame
	void Update () {
        //if the z is over 180 and under 0 then flip
        //Debug.Log(transform.parent.transform.position.z);
        if (transform.parent.transform.rotation.z<0)
        {
            //flip
            GetComponent<SpriteRenderer>().flipX = true;
        }else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (Input.GetButton("leftBumper0"))
        {
            Debug.Log("this works D:");
            GetComponent<SpriteRenderer>().sprite = catchBurg;
        }else
        {
            GetComponent<SpriteRenderer>().sprite = arrow;
        }
	}
}
