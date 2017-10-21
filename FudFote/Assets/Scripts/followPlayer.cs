using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour {
    public GameObject player;
    public GameObject hand;

    public GameObject bun1;
    public GameObject patty1;
    public GameObject lettuce1;
    public GameObject cheese1;
    public GameObject patty2;
    public GameObject ketchup;
    public GameObject bun2;

    public bool bun1B;
    public bool patty1B;
    public bool lettuce1B;
    public bool cheese1B;
    public bool patty2B;
    public bool ketchupB;
    public bool bun2B;
    // Use this for initialization
    void Start () {
        bun1.GetComponent<SpriteRenderer>().enabled = false;
        patty1.GetComponent<SpriteRenderer>().enabled = false;
        lettuce1.GetComponent<SpriteRenderer>().enabled = false;
        cheese1.GetComponent<SpriteRenderer>().enabled = false;
        patty2.GetComponent<SpriteRenderer>().enabled = false;
        ketchup.GetComponent<SpriteRenderer>().enabled = false;
        bun2.GetComponent<SpriteRenderer>().enabled = false;

        bun1B = false;
        patty1B = false;
        lettuce1B=false;
        cheese1B=false;
        patty2B=false;
        ketchupB=false;
        bun2B=false;
}
	
	// Update is called once per frame
	void Update () {
        if (player != null)
        {
            if (player.GetComponent<player>().heldItems.Count > 0)
            {
                hand.GetComponent<SpriteRenderer>().enabled = true;
                if (bun1B == true)
                {
                    bun1.GetComponent<SpriteRenderer>().enabled = true;
                }else if(bun1B==false)
                {
                    bun1.GetComponent<SpriteRenderer>().enabled = false;
                }
                //--------------------------------------------------------
                if (patty1B == true)
                {
                    patty1.GetComponent<SpriteRenderer>().enabled = true;
                }
                else if (patty1B == false)
                {
                    patty1.GetComponent<SpriteRenderer>().enabled = false;
                }
                //--------------------------------------------------------
                if (lettuce1B == true)
                {
                    lettuce1.GetComponent<SpriteRenderer>().enabled = true;
                }
                else if (lettuce1B == false)
                {
                    lettuce1.GetComponent<SpriteRenderer>().enabled = false;
                }
                //--------------------------------------------------------
                if (cheese1B == true)
                {
                    cheese1.GetComponent<SpriteRenderer>().enabled = true;
                }
                else if (cheese1B == false)
                {
                    cheese1.GetComponent<SpriteRenderer>().enabled = false;
                }
                //--------------------------------------------------------
                if (patty2B == true)
                {
                    patty2.GetComponent<SpriteRenderer>().enabled = true;
                }
                else if (patty2B == false)
                {
                    patty2.GetComponent<SpriteRenderer>().enabled = false;
                }
                //--------------------------------------------------------
                if (ketchupB == true)
                {
                    ketchup.GetComponent<SpriteRenderer>().enabled = true;
                }
                else if (ketchupB == false)
                {
                    ketchup.GetComponent<SpriteRenderer>().enabled = false;
                }
                //--------------------------------------------------------
                if (bun2B == true)
                {
                    bun2.GetComponent<SpriteRenderer>().enabled = true;
                }
                else if (bun2B == false)
                {
                    bun2.GetComponent<SpriteRenderer>().enabled = false;
                }
                bun1B = false;
                patty1B = false;
                lettuce1B = false;
                cheese1B = false;
                patty2B = false;
                ketchupB = false;
                bun2B = false;
                //render the right components
                for (int i = 0; i < player.GetComponent<player>().heldItems.Count; i++)
                {
                    if (player.GetComponent<player>().heldItems[i].id == 0)
                    {
                        bun1B=true;
                    }
                    if (player.GetComponent<player>().heldItems[i].id == 1)
                    {
                        patty1B=true;
                    }
                    if (player.GetComponent<player>().heldItems[i].id == 2)
                    {
                        lettuce1B=true;
                    }
                    if (player.GetComponent<player>().heldItems[i].id == 3)
                    {
                        cheese1B=true;
                    }
                    if (player.GetComponent<player>().heldItems[i].id == 4)
                    {
                        patty2B = true;
                    }
                    if (player.GetComponent<player>().heldItems[i].id == 5)
                    {
                        ketchupB = true;
                    }
                    if (player.GetComponent<player>().heldItems[i].id == 6)
                    {
                        bun2B = true;
                    }
                }
            }else
            {
                hand.GetComponent<SpriteRenderer>().enabled = false;

                bun1.GetComponent<SpriteRenderer>().enabled = false;
                patty1.GetComponent<SpriteRenderer>().enabled = false;
                lettuce1.GetComponent<SpriteRenderer>().enabled = false;
                cheese1.GetComponent<SpriteRenderer>().enabled = false;
                patty2.GetComponent<SpriteRenderer>().enabled = false;
                ketchup.GetComponent<SpriteRenderer>().enabled = false;
                bun2.GetComponent<SpriteRenderer>().enabled = false;

                bun1B = false;
                patty1B = false;
                lettuce1B = false;
                cheese1B = false;
                patty2B = false;
                ketchupB = false;
                bun2B = false;
            }
            Vector3 pos = player.transform.position;
            transform.position = pos;
        }

	}
}
