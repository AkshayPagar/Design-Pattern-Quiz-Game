using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitGameReceiver : MonoBehaviour, IReceiver
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void doAction()
    {
        Application.Quit();
    }
}
