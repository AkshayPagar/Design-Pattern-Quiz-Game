﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour, IDisplayComponent {

    public Text ScoreText;
    ScoreBoardManager scoreBoardManager;

    // Use this for initialization
    void Start () {
		
    }
    public void display()
    {
        scoreBoardManager = ScoreBoardManager.GetInstance();
        ScoreText.text = "Score : " + scoreBoardManager.getScore();

    }
    // Update is called once per frame
    void Update () {

        ScoreText.text = "Score : " + scoreBoardManager.getScore();
    }

    
    public void addSubComponent(IDisplayComponent c)
    {
    }
}
