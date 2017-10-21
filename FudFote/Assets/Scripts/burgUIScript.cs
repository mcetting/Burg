using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class burgUIScript : MonoBehaviour {
    public GameObject player;

    public GameObject bun1;
    public GameObject patty1;
    public GameObject lettuce1;
    public GameObject cheese1;
    public GameObject patty2;
    public GameObject ketchup1;
    public GameObject bun2;

    player p;

    private bool drawBun2;
    private bool drawBun1;
    private bool drawKetchup;
    private bool drawPatty2;
    private bool drawCheese;
    private bool drawPatty1;
    private bool drawLettuce;

    // Use this for initialization
    void Start () {

        drawBun2=false;
        drawBun1=false;
        drawKetchup=false;
        drawPatty2=false;
        drawCheese=false;
        drawPatty1=false;
        drawLettuce=false;
}

    // Update is called once per frame
    void Update() {
		if (player != null) {
			player p = player.GetComponent<player> ();
			if (drawBun1 == true) {
				bun1.GetComponent<Image> ().enabled = true;
			} else if (drawBun1 == false) {
				bun1.GetComponent<Image> ().enabled = false;
			}
			//----------------------------------------------
			if (drawPatty1 == true) {
				patty1.GetComponent<Image> ().enabled = true;
			} else if (drawPatty1 == false) {
				patty1.GetComponent<Image> ().enabled = false;
			}
			//----------------------------------------------
			if (drawLettuce == true) {
				lettuce1.GetComponent<Image> ().enabled = true;

			} else if (drawLettuce == false) {
				lettuce1.GetComponent<Image> ().enabled = false;
			}
			//----------------------------------------------
			if (drawCheese == true) {
				cheese1.GetComponent<Image> ().enabled = true;

			} else if (drawCheese == false) {
				cheese1.GetComponent<Image> ().enabled = false;
			}
			//----------------------------------------------
			if (drawPatty2 == true) {
				patty2.GetComponent<Image> ().enabled = true;
			} else if (drawPatty2 == false) {
				patty2.GetComponent<Image> ().enabled = false;
			}
			//----------------------------------------------
			if (drawKetchup == true) {
				ketchup1.GetComponent<Image> ().enabled = true;

			} else if (drawKetchup == false) {
				ketchup1.GetComponent<Image> ().enabled = false;
			}
			//----------------------------------------------
			if (drawBun2 == true) {
				bun2.GetComponent<Image> ().enabled = true;

			} else if (drawBun2 == false) {
				bun2.GetComponent<Image> ().enabled = false;
			}
			drawBun1 = false;
			drawPatty1 = false;
			drawLettuce = false;
			drawCheese = false;
			drawPatty2 = false;
			drawKetchup = false;
			drawBun2 = false;
			//----------------------------------------------
			for (int i = 0; i < p.heldItems.Count; i++) {
				if (p.heldItems [i].id == 0) {
					//draw the bun
					drawBun1 = true;
				} else if (p.heldItems [i].id == 1) {
					//draw the bun
					drawPatty1 = true;
				} else if (p.heldItems [i].id == 2) {
					//draw the bun
					drawLettuce = true;
				} else if (p.heldItems [i].id == 3) {
					//draw the bun
					drawCheese = true;
				} else if (p.heldItems [i].id == 4) {
					//draw the bun
					drawPatty2 = true;
				} else if (p.heldItems [i].id == 5) {
					//draw the bun
					drawKetchup = true;
				} else if (p.heldItems [i].id == 6) {
					//draw the bun
					drawBun2 = true;
				}
			}
		} else {
			bun1.GetComponent<Image> ().enabled = false;
			patty1.GetComponent<Image> ().enabled = false;
			lettuce1.GetComponent<Image> ().enabled = false;
			cheese1.GetComponent<Image> ().enabled = false;
			patty2.GetComponent<Image> ().enabled = false;
			ketchup1.GetComponent<Image> ().enabled = false;
			bun2.GetComponent<Image> ().enabled = false;
		}

    
	}
}
