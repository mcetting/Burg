using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tableManager : MonoBehaviour {
    public GameObject sprites;
    public GameObject[] pots;
	// Use this for initialization
	void Start () {
        for(int i = 0; i < pots.Length; i++)
        {
            pots[i].SetActive(false);
        }
	}
    float timer;
    float waitTime = 10f;
    void spawnPot() { 
        int item = Random.Range(0, 7);
        //0-6

        int rand = Random.Range(0, pots.Length);
        if (pots[rand].transform.childCount != 0)
        {
            Destroy(pots[rand].transform.GetChild(0).gameObject);
        }
        pots[rand].SetActive(true);
        GameObject itemC = Instantiate(new GameObject());
        itemC.transform.SetParent(pots[rand].transform);
        itemC.transform.position = new Vector3(pots[rand].transform.position.x, pots[rand].transform.position.y+.3f, pots[rand].transform.position.z);
        itemC.AddComponent<SpriteRenderer>();
        itemC.GetComponent<SpriteRenderer>().sprite = sprites.GetComponent<ItemSpawner>().itemSprites[item];
        itemC.GetComponent<SpriteRenderer>().sortingOrder = 51;
        itemC.transform.localScale = new Vector2(1.2f,1.2f);
        pots[rand].GetComponent<healUpbb>().curId = item;
    }
    public static void usePot()
    {

    }
	// Update is called once per frame
	void Update () {
        //every 10 seconds theres a random heal
        if (timer + waitTime <= Time.time)
        {
            spawnPot();
            timer = Time.time;
        }
	}
}
