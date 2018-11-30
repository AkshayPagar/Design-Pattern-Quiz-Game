using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreBoardManager : MonoBehaviour, IPlayerResponseObserver
{

    public Text ScoreText;
    public Text DisplayText;
    private  int score = 0;


    // Use this for initialization
    void Start()
    {
        //DontDestroyOnLoad(gameObject);
        score = PlayerPrefs.GetInt("score", 0);
        foreach (var subject in FindObjectsOfType<PlayerResponseManager>())
            subject.attach(this);

        ScoreText.text = "Score : " + score.ToString();
    }

   
    // Update is called once per frame
    void Update()
    {


    }
     void OnDestroy()
    {
        foreach (var subject in FindObjectsOfType<PlayerResponseManager>())
            subject.detach(this);
    }

    public void updateStatus()
    {
        
        Debug.Log("Observer called");
        score = score + 5; PlayerPrefs.SetInt("score", score);
        ScoreText.text = "Score : " + score;
        DisplayText.text = "Good Job!!!";
        
    }
}
