using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class charSelect : MonoBehaviour {
    public static int readyPlayers;
    public GameObject[] players;

    public GameObject[] playerChoice;
    public static bool[] playerSelectedAlready;
    // Use this for initialization
    void Start () {
        readyPlayers = 0;
        playerSelectedAlready = new bool[dataManager.max_players];
        for(int i = 0; i < dataManager.max_players; i++) {
            playerSelectedAlready[i] = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(readyPlayers);
        if (readyPlayers >= 1 && Input.GetButton("select"))
        {
            dataManager.num_players = readyPlayers;
            SceneManager.LoadScene(2);
        }
        for(int i = 0; i < dataManager.max_players; i++) {
            if (Input.GetButton("start" + i))
            {
                Debug.Log("start pressed");
                players[i].SetActive(false);
                playerChoice[i].SetActive(true);
            }
        }
    }
}
