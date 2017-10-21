using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class charChange : MonoBehaviour {
    public Sprite[] player;
    int index;
    bool once;
    public int id;
	// Use this for initialization
	void Start () {
        index = 0;
	}
	
	// Update is called once per frame
	void Update () {
        float movHor = 0;
        if (Input.GetButton("A" + id))
        {
            dataManager.playerSpriteIndex[id] = index;
            Debug.Log(index);
            charSelect.readyPlayers++;
            transform.parent.gameObject.SetActive(false);
            
            if(charSelect.playerSelectedAlready[id] == true) {
                charSelect.readyPlayers--;
            }
            charSelect.playerSelectedAlready[id] = true;
        }
        GetComponent<Image>().sprite = player[index];
        //read inputs to go through it
        movHor = Input.GetAxis("Horizontal" + id);
        if (movHor < 0&&once)
        {
            //left
            if (index == 1)
            {
                index--;
            }else if(index == 2)
            {
                index--;
            }
            once = false;
        }else if (movHor > 0&&once)
        {
            //right
            if (index == 0)
            {
                index++;
            }else if(index == 1)
            {
                index++;
            }
            once = false;
        }else if(movHor==0)
        {
            //0
            once = true;
        }
	}
}
