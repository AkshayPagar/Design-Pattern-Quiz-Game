using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuScript : MonoBehaviour
{

    newGameReceiver Object;

    public string[] menuStrings;
    public string newGameLevel;
    public GameObject Banner;
    public Text BannerText;
    Menu newGame;
    Menu Credits;
    Menu Help;
    Menu Instructions;
    Menu quit;
    ICommand startNewGame;
    ICommand quitGame;
    ICommand showHelp;
    ICommand showCredits;
    ICommand showInstr;
    IReceiver nGame;
    IReceiver qGame;
    IReceiver sHelp;
    IReceiver sCredits;
    IReceiver sInstr;

    public Text[] menuText;
    int selectIndex;
    int prevIndex;

    int axisDirectionPressed;
    int axisDirection;

    Color transparentColor;

    void Start()
    {
        initializeMenu();
        initializeCommand();
        initializeReceiver();
        setReceiver();
        setCommand();
        PlayerPrefs.SetInt("score", 0);
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

    void initializeMenu()
    {
        newGame = new Menu();
        Credits = new Menu();
        Help = new Menu();
        Instructions = new Menu();
        quit = new Menu();
    }

    void initializeCommand()
    {
        startNewGame = new ConcreteCommand();
        quitGame = new ConcreteCommand();
        showHelp = new ConcreteCommand();
        showCredits = new ConcreteCommand();
        showInstr = new ConcreteCommand();
    }

    void initializeReceiver()
    {
        nGame = new newGameReceiver();
        qGame = new quitGameReceiver();
        sHelp = new showHelpReceiver();
        sCredits = new showCreditsReceiver();
        sInstr = new showInstrReceiver();

    }

    void setCommand()
    {
        newGame.setCommand(startNewGame);
        quit.setCommand(quitGame);
        Help.setCommand(showHelp);
        Credits.setCommand(showCredits);
        Instructions.setCommand(showInstr);
    }

    void setReceiver()
    {
        startNewGame.setReceiver(nGame);
        quitGame.setReceiver(qGame);
        showHelp.setReceiver(sHelp);
        showCredits.setReceiver(sCredits);
        showInstr.setReceiver(sInstr);
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
                    //Object =newGameReceiverGO.GetComponent<newGameReceiver>();
                    newGame.invoke();
                    break;

                //Continue
                case 1:
                    Credits.invoke();
                    break;

                //Options
                case 2:
                    Help.invoke();
                    break;

                //Quit
                case 3:
                    Instructions.invoke();
                    break;

                //Quit
                case 4:
                    quit.invoke();
                    break;
            }
        }
    }


    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

}
