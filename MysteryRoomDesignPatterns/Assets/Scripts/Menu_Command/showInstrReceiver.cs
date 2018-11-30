using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class showInstrReceiver : MonoBehaviour, IReceiver
{
    public GameObject Banner;
    public Text BannerText;
    public static bool show = false;
    // Use this for initialization
    void Start()
    {
        Banner.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (show == true)
        {
            BannerText.text = "                                                                     Instructions:" +
                   " \n \u2022Players will be presented with 7 scenes which depicts real-world examples of Design Patterns." +
                   " \n \u2022Each scene will have 4 design pattern options to choose from." +
                   " \n \u2022The game objects in the scenes may be clicked for a change in their behaviour." +
                   " \n \u2022The duration of the entire game is 100 seconds." +
                   " \n \u2022Every correct answer increases the score by 5 points." +
                   " \n \u20223 lives will be provided in the beginning of the game and every wrong answer reduces the lives by 1." +
                   " \n \u2022The game ends if the lives gets exhausted, the time is up, or all the 7 questions are attempted." +
                   " \n \u2022Player can use the hint only once in the whole game.";
            if (Banner.activeInHierarchy == false)
                Banner.SetActive(true);
        }
        else
            Banner.SetActive(false);
    }

    public void doAction()
    {
        Debug.Log("Insr");
        if (!show)
            show = true;
        else
            show = false;
    }
}
