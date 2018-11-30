using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteCommand : MonoBehaviour , ICommand{

    private IReceiver theReceiver;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void execute()
    {
        theReceiver.doAction();
    }

    public void setReceiver(IReceiver target)
    {
        theReceiver = target;
    }

}
