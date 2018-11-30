using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScreenManager : MonoBehaviour {


	// Use this for initialization
    void Start () {

        var gameScreen = new CompositeGameScreen();

        var timer = GameObject.FindObjectOfType<TimeScript>();
        gameScreen.addSubComponent(timer);

        var score = GameObject.FindObjectOfType<ScoreBoard>();
        gameScreen.addSubComponent(score);

        var life = GameObject.FindObjectOfType<LifeScript>();
        gameScreen.addSubComponent(life);

        var hint = GameObject.FindObjectOfType<HintScript>();
        gameScreen.addSubComponent(hint);

        gameScreen.display();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
