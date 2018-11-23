using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {

    public SimpleObjectPool answerButtonObjectPool;
    public Scene scene;
    public Transform answerButtonParent;

    private DataController dataController;
    private QuestionData[] questionPool;
    private List<GameObject> answerButtonGameObjects = new List<GameObject>();

    private float timeRemaining;
    private int questionIndex; 
    private int playerScore;


	// Use this for initialization
	void Start () {
        dataController = FindObjectOfType<DataController>();
        questionPool = dataController.questions;
        timeRemaining = dataController.timeLimit;

        playerScore = 0;
        questionIndex = 0;
        ShowQuestion();
	}


    public void ShowQuestion() {
        RemoveAnswerButtons();
        QuestionData questionData = questionPool[questionIndex]; 
        scene = questionData.scene;

        for (int i = 0; i < questionData.answers.Length; i++) {
            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
            answerButtonGameObject.transform.SetParent(answerButtonParent);
            answerButtonGameObjects.Add(answerButtonGameObject);

            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.SetUp(questionData.answers[i]);
        }
    }

    // Remove Answer Buttons that are currently in use
    private void RemoveAnswerButtons() {
        while (answerButtonGameObjects.Count > 0) {
            answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
            answerButtonGameObjects.RemoveAt(0);
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
