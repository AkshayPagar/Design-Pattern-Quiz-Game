using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeScript : MonoBehaviour {

    public Text timerText;

    public static float timer = 100.0f;

    public string MenuScene = "";
    int counter = 0;


	// Use this for initialization
	void Start ()
    {
        timerText.text = "Time: " + timer.ToString(); 
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer = timer - 0.015f;
        if (timer >= 0.0f)
        {
            timerText.text = "Time: " + (int)timer;
        }
        else
        {
            counter += 1;
            timerText.text = "GAME OVER!!!";
            if (counter >= 200)
            {

                SceneManager.LoadScene(MenuScene);
            }
        }
    }
}
