using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;


public class DataController : MonoBehaviour {

    public int timeLimit;
    public int pointsAddedForCorrectAnswers;
    public QuestionData[] questions;
    public Scene[] scenes;
   // public AnswerData[] answers;


    // Use this for initialization
    void Start() {
        DontDestroyOnLoad(gameObject); // Object will persist on loading new scenes
        SceneManager.LoadScene("MenuScene");
        InitScenes();
    }

    public void InitScenes()
    {
        int sceneCount = 3;
            //SceneManager.sceneCountInBuildSettings;
        scenes = new Scene[sceneCount];

        for (int i = 0; i < sceneCount; i++)
        {
            // questions[i] = Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
            scenes[i] = SceneManager.GetSceneByBuildIndex(sceneCount);
            questions[i].scene = scenes[i];

        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
