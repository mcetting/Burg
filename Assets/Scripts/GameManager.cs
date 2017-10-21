using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public AudioSource[] music;

    public static int playerCount;
    public GameObject winner;
    public GameObject burg;
    public GameObject light;
    public AudioSource siren;
    public static bool burgAchieved;
    public GameObject pauseText;
    bool activated;
    Color c;
	// Use this for initialization
	void Start () {
        int rand = Random.Range(0, music.Length);
        music[rand].Play();

        playerCount = dataManager.num_players;
        burgAchieved = false;
        activated = false;
        c = light.GetComponent<Light>().color;
        pauseText.SetActive(false);
        QualitySettings.vSyncCount = 1;
        Screen.SetResolution(660, 360, true);
	}
	public IEnumerator go()
    {
        yield return new WaitForSeconds(2f);
        light.GetComponent<Light>().color = c;
        siren.Stop();
        activated = false;
        burgAchieved = false;

    }
	// Update is called once per frame
	void Update () { 
        if(playerCount<=1){
            //play winner plz
            //Debug.Log("Winner");
            winner.SetActive(true);
            if (Input.GetButtonDown("start"))
            {
                SceneManager.LoadScene(1);
            }
        }
        else {
            if (Input.GetButtonDown("start"))
            {
                if(Time.timeScale == 1) {
                    pauseText.SetActive(true);
                    Time.timeScale = 0;
                }
                else {
                    Time.timeScale = 1;
                    pauseText.SetActive(false);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            burgAchieved = true;
        }
        if (burgAchieved == true&&activated==false)
        {
            //burgAchieved
            siren.Play();
            //play the animation
            activated = true;
            light.GetComponent<Light>().color = Color.red;
            burg.GetComponent<Animator>().Play("burg");
            StartCoroutine(go());
        }
	}
}
