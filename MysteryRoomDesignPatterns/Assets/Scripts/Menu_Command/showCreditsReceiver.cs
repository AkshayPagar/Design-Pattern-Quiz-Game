using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class showCreditsReceiver : MonoBehaviour, IReceiver{
    public GameObject Banner;
    public Text BannerText;
    public static bool show = false;

    // Use this for initialization
    void Start () {
        Banner.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        Banner.SetActive(true);
        if (show == true)
        {
            BannerText.text = "Credits: \n Project Team Members: " +
                                   "\n Akshay Pagar" +
                                   "\n Mayur Barge" +
                                   "\n Sneha Thomas" +
                                   "\n Nikita Bairagi" +
                                   "\n\n Special Thanks to: Paul Nguyen";
            if (Banner.activeInHierarchy == false)
            {
              Banner.SetActive(true);
            }
        }
        else
            Banner.SetActive(false);
    }

    public void doAction()
    {
        Debug.Log("Credits");
        if (!show)
        {
            show = true;
        }
        else
            show = false;
    }
}
