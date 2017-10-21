using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ydepth : MonoBehaviour {
    bool once;
    bool srslyOnce;
    bool fresh;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (transform.position.y < collision.transform.position.y - .5f)
            {
                once = true;
                srslyOnce = true;
            }

           // fresh = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            GetComponent<SpriteRenderer>().sortingOrder = 1;
            //collision.GetComponent<player>().ren.GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            player p = collision.GetComponent<player>();
            if (transform.position.y < collision.transform.position.y)
            {
                //Debug.Log("less");
                if (once) {
                    Debug.Log("player in back");
                    if (p.ren.GetComponent<SpriteRenderer>().sortingOrder <= GetComponent<SpriteRenderer>().sortingOrder && fresh)
                    {
                        Debug.Log("already in a collider");
                        fresh = false;
                        if (p.ren.GetComponent<SpriteRenderer>().sortingOrder >= GetComponent<SpriteRenderer>().sortingOrder)
                        {
                            //GetComponent<SpriteRenderer>().sortingOrder = collision.GetComponent<player>().ren.GetComponent<SpriteRenderer>().sortingOrder + 2;
                        }
                    }
                    else
                    {
                        if (transform.position.y + 1f <= collision.transform.position.y)
                        {

                            GetComponent<SpriteRenderer>().sortingOrder=p.ren.GetComponent<SpriteRenderer>().sortingOrder + 1;
                            srslyOnce = true;
                            once = false;
                            

                        }
                    }

                }
                
            }else if (transform.position.y >= collision.transform.position.y)
            {
                //Debug.Log("reset");
                once = true;
                if (srslyOnce)
                {
                    //Debug.Log("behind");
                    if(p.ren.GetComponent<SpriteRenderer>().sortingOrder >= GetComponent<SpriteRenderer>().sortingOrder&&fresh)
                    {
                        Debug.Log("already in a collider");
                        fresh = false;
                        if (p.ren.GetComponent<SpriteRenderer>().sortingOrder<= GetComponent<SpriteRenderer>().sortingOrder)
                        {
                            //GetComponent<SpriteRenderer>().sortingOrder = collision.GetComponent<player>().ren.GetComponent<SpriteRenderer>().sortingOrder - 1;
                        }

                    }
                    else
                    {
                        if (transform.position.y-2f <= collision.transform.position.y)
                        {
                            Debug.Log("player in front");
                            p.ren.GetComponent<SpriteRenderer>().sortingOrder = GetComponent<SpriteRenderer>().sortingOrder + 2;
                            srslyOnce = false;
                            once = true;
                        }
                        

                    }

                }
            }
        }
    }
    
    // Use this for initialization
    void Start () { 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
