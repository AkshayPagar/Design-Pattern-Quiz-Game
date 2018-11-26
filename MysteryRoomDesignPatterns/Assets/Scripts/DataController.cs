using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;


public class DataController : MonoBehaviour {

    public int timeLimit;
    public int pointsAddedForCorrectAnswers;
    public List<QuestionData> questions = new List<QuestionData>();

    // Use this for initialization
    void Start() {
        DontDestroyOnLoad(gameObject); // Object will persist on loading new scenes
        SceneManager.LoadScene("MenuScene");
        InitScenes();
    }

    public void InitScenes()
    {
        int sceneCount = (SceneManager.sceneCountInBuildSettings);
        QuestionData question = new QuestionData();       

        for (int i = 3; i < sceneCount; i++)
        {
           question.scenePath = Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
           questions.Add(question);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
