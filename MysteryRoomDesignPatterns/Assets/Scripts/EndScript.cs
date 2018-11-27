using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour {
    public string newLevel;
    public Text ScoreText;
    public static int score;
    // Use this for initialization
    void Start () {
        score = ScoreScript.score;
    }
	
	// Update is called once per frame
	void Update () {
        string fscore = "";
        fscore += "GAME OVER!!!\n\n";
        if (score >= 35)
        {
            fscore+= "Congratulations on full score!!! \n\n";
        }
        fscore += "Your Score is: " + score;
        ScoreText.text = fscore;

	}

    void GoHome()
    {
        SceneManager.LoadScene(newLevel);
    }
}
