using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    public Text ScoreText;

    public static int score = 0;


	// Use this for initialization
	void Start ()
    {
        ScoreText.text = "Score : " + score.ToString(); 
	}
	
	// Update is called once per frame
	void Update ()
    {

        ScoreText.text = "Score : " + score.ToString();
    }

    void RightClick()
    {
        score = score + 5;
    }
}
