using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour {

    public RoundData roundData;
	// Use this for initialization
	void Start() {
        DontDestroyOnLoad(gameObject); // Object will persist on loading new scenes
        SceneManager.LoadScene("MenuScene");

    
	}

    public RoundData getRoundData() {
        return roundData;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
