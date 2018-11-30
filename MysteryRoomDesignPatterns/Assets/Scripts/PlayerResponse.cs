using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerResponse : MonoBehaviour {

    PlayerResponseManager playerResponseManager;
    private GameObject button;

    // Use this for initialization
    void Start () {

            playerResponseManager = PlayerResponseManager.GetInstance();

    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject != null)
        {
            button = EventSystem.current.currentSelectedGameObject;
            playerResponseManager.checkAnswerKey(button);
        }
    }
}
