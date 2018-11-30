using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuScript : MonoBehaviour {

    public string[] menuStrings;
    public string newGameLevel;
    public GameObject Banner;
    public Text BannerText;

    public Text[] menuText;
    int selectIndex;
    int prevIndex;

    int axisDirectionPressed;
    int axisDirection;

    Color transparentColor;

    void Start()
    {
        transparentColor = new Color(1f, 1f, 1f, 0.5f);
        selectIndex = 0;
        prevIndex = selectIndex;
        InitializeText();
        axisDirection = 0;
        axisDirectionPressed = 0;
        PlayerPrefs.SetInt("score", 0);
        TimeScript.timer = 40.0f;
        LifeScript.life = 3;
        HintScript.hints = 1;
    }

    void Update()
    {
        CheckAxis();
        CheckForArrowKeys();
        CheckForConfirmButton();
        ResetCheckAxis();
    }

    void CheckAxis()
    {
        if (Input.GetAxis("Vertical") == 1 && axisDirection != 1)
        {
            axisDirection = 1;
            axisDirectionPressed = 1;
        }
        else if (Input.GetAxis("Vertical") == -1 && axisDirection != -1)
        {
            axisDirection = -1;
            axisDirectionPressed = -1;
        }
        else if (Input.GetAxis("Vertical") == 0 && axisDirection != 0)
        {
            axisDirection = 0;
            axisDirectionPressed = 0;
        }
    }

    void ResetCheckAxis()
    {
        axisDirectionPressed = 0;
    }

    void UpdateMenu(int newIndex, int oldIndex)
    {
        menuText[oldIndex].color = transparentColor;
        menuText[newIndex].color = Color.white;
    }

    void InitializeText()
    {
        for (int i = 0; i < menuStrings.Length; i++)
        {
            menuText[i].text = menuStrings[i];
            if (i != selectIndex)
                menuText[i].color = transparentColor;
        }
    }

    void CheckForArrowKeys()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || axisDirectionPressed == 1)
        {
            selectIndex--;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow) || axisDirectionPressed == -1)
        {
            selectIndex++;
        }
        if (selectIndex > menuStrings.Length - 1)
            selectIndex -= menuStrings.Length;
        else if (selectIndex < 0)
            selectIndex += menuStrings.Length;

        if (selectIndex != prevIndex)
        {
            UpdateMenu(selectIndex, prevIndex);
            prevIndex = selectIndex;
        }
    }

    void CheckForConfirmButton()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            switch (selectIndex)
            {
                //New Game
                case 0:
                    SceneManager.LoadScene(newGameLevel);
                    break;

                //Continue
                case 1:
                    BannerText.text = "Credits: \n Project Team Members: " +
                        "\n Akshay Pagar" +
                        "\n Mayur Barge" +
                        "\n Sneha Thomas" +
                        "\n Nikita Bairagi" +
                        "\n\n Special Thanks to: Paul Nguyen";
                    if (Banner.activeInHierarchy == true)
                        Banner.SetActive(false);
                    else
                        Banner.SetActive(true);
                    break;

                //Options
                case 2:
                    BannerText.text = "                                                         Design Pattern Catalog " + 
                    "\n	  Factory Method                              :-  subclass of object that is instantiated	" +
                    "\n	  Singleton                                        :-  the sole instance of a class	" +
                    "\n	  Adapter                                          :-  interface to an object	" +
                    "\n	  Composite                                      :-  structure and composition of an object	" +
                    "\n	  Decorator                                      :-  responsibilities of an object without subclassing	" +
                    "\n	  Proxy                                             :-  how an object is accessed; its location	" +
                    "\n	  Chain of Responsibility                 :-  object that can fulfill a request	" +
                    "\n	  Command                                      :-  when and how a request is fulfilled	" +
                    "\n	  Iterator                                          :-  how an aggregate's elements are accessed,traversed	" +
                    "\n	  Observer                                       :-  number of objects that depend on another object; how the dependent objects stay up to date	" +
                    "\n	  State                                              :-  states of an object	" +
                    "\n	  Strategy                                        :-  an algorithm	";
                    BannerText.alignment = TextAnchor.UpperLeft;
                    BannerText.fontSize = 15;
                    if (Banner.activeInHierarchy == true)
                        Banner.SetActive(false);
                    else
                        Banner.SetActive(true);
                    Debug.Log("Help ");
                    break;

                //Quit
                case 3:
                    BannerText.text = "                                                                     Instructions:" +
                    " \n \u2022Players will be presented with 7 scenes which depicts real-world examples of Design Patterns." +
                    " \n \u2022Each scene will have 4 design pattern options to choose from." +
                    " \n \u2022The game objects in the scenes may be clicked for a change in their behaviour." +
                    " \n \u2022The duration of the entire game is 40 seconds." +
                    " \n \u2022Every correct answer increases the score by 5 points." +
                    " \n \u20223 lives will be provided in the beginning of the game and every wrong answer reduces the lives by 1." +
                    " \n \u2022The game ends if the lives gets exhausted, the time is up, or all the 7 questions are attempted." +
                    " \n \u2022Player can use the hint only once in the whole game.";     
                    BannerText.alignment = TextAnchor.UpperLeft;
                    BannerText.fontSize = 20;
                    if (Banner.activeInHierarchy == true)
                        Banner.SetActive(false);
                    else
                        Banner.SetActive(true);
                    break;

                //Quit
                case 4:
                    Application.Quit();
                    break;
            }
        }
    }


    public void StartGame() {
        SceneManager.LoadScene("Game");
    }

}
