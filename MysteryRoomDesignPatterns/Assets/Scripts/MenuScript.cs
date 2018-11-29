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
                    BannerText.text = "Help: ";
                    if (Banner.activeInHierarchy == true)
                        Banner.SetActive(false);
                    else
                        Banner.SetActive(true);
                    Debug.Log("Help ");
                    break;

                //Quit
                case 3:
                    BannerText.text = "Instructions:";
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
