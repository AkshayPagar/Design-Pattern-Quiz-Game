using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour, IInvoker {

    private ICommand theCommand;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setCommand(ICommand cmd)
    {
        theCommand = cmd;
    }

    public void invoke()
    {
        theCommand.execute();
    }

}
