using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintScript : MonoBehaviour {
    public Text HintButton;
    public GameObject panel;
    public Text Hint;
    HintManager hintManager;
    void Start () {
        Debug.Log("Init");
        hintManager = HintManager.GetInstance();
        panel.SetActive(false);
        Hint.enabled = false;
    }

    // Update is called once per frame
    void Update() 
    {
        HintButton.text = "Hints: " + hintManager.GetHintCount();
    }

    void ShowHint()
    {
        if (hintManager.GetHintCount().CompareTo(1) == 0)
        {
            if (panel.activeInHierarchy == false)
                panel.SetActive(true);
            Hint.enabled = true;
        }
        else
        {
            if (panel.activeInHierarchy == true)
            {
                panel.SetActive(false);
            }
            Hint.enabled = false;
        }
        hintManager.Request();
    }
}

