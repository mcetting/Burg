using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getP1Hp : MonoBehaviour {
    public GameObject player1;
    public Image g;
    bool inc;
    int scaleBase = 1;
	// Use this for initialization
	void Start () {
        inc = false;
        g = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if (player1 != null) {
			int hp = player1.GetComponent<player> ().hp;
			if (g != null) {
				g.rectTransform.localScale = new Vector2 (0.1f * scaleBase * hp, 3);
			}

			//GetComponent<Text>().text = "HP: " + player1.GetComponent<player>().hp.ToString();



			// whyyyyyyyyyy???
			/*
            switch (player1.GetComponent<player>().hp)
            {
                case 0:
                    if (g != null)
                    {
                        g.rectTransform.localScale = new Vector2(0, 3);
                    }
                    break;
                case 1:
                    if (g != null)
                    {
                        g.rectTransform.localScale = new Vector2(scaleBase * .1f, 3);
                    }
                    break;
                case 2:
                    if (g != null)
                    {
                        g.rectTransform.localScale = new Vector2(scaleBase * .2f, 3);
                    }
                    break;
                case 3:
                    if (g != null)
                    {
                        g.rectTransform.localScale = new Vector2(scaleBase * .3f, 3);
                    }
                    break;
                case 4:
                    if (g != null)
                    {
                        g.rectTransform.localScale = new Vector2(scaleBase * .4f, 3);
                    }
                    break;
                case 5:
                    if (g != null)
                    {
                        g.rectTransform.localScale = new Vector2(scaleBase * .5f, 3);
                    }
                    break;
                case 6:
                    if (g != null)
                    {
                        g.rectTransform.localScale = new Vector2(scaleBase * .6f, 3);
                    }
                    break;
                case 7:
                    if (g != null)
                    {
                        g.rectTransform.localScale = new Vector2(scaleBase * .7f, 3);
                    }
                    break;
                case 8:
                    if (g != null)
                    {
                        g.rectTransform.localScale = new Vector2(scaleBase * .8f, 3);
                    }
                    break;
                case 9:
                    if (g != null)
                    {
                        g.rectTransform.localScale = new Vector2(scaleBase*.9f, 3);
                    }
                    break;

                case 10:
                    if (g != null)
                    {
                        g.rectTransform.localScale = new Vector2(1, 3);
                    }

                    break;
            }*/
		} else {
			g.enabled = false;
		}
	}
}
