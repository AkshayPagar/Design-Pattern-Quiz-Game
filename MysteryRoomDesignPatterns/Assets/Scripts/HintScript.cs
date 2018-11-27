using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintScript : MonoBehaviour {

    public GameObject panel;
    public Text Hint;
    public bool show = false;
  // Use this for initialization
	void Start () {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (show)
        {
            if(panel.activeInHierarchy == false)
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
            show = true;
    }


}
