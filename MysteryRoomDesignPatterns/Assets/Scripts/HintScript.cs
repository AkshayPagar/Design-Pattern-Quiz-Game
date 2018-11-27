using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintScript : MonoBehaviour {
    public Text HintButton;
    public GameObject panel;
    public Text Hint;
    public bool show = false;
    public static int hints = 1;
    // Use this for initialization
    void Start () {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        
        if(hints>=0)
          HintButton.text = "Hints: " + hints;
        else
            HintButton.text = "Hints: 0";

        if (show && hints>=0)
        {
            if (panel.activeInHierarchy == false)
                panel.SetActive(true);
            Hint.enabled = true;
        }
        else
        {

            if (panel.activeInHierarchy == true)
                panel.SetActive(false);
            Hint.enabled = false;
            
        }
    }

    void ShowHint()
    {

        //Debug.Log("ShowHint clicked");
        if (show)
            show = false;
        else
        {
            show = true;
            if(hints>=0)
            hints--;
        }
    }


}
