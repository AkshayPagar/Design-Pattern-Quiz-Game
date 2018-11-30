using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class showHelpReceiver : MonoBehaviour, IReceiver
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
            if (Banner.activeInHierarchy == false)
                Banner.SetActive(true);
        }
        else
            Banner.SetActive(false);
    }

    public void doAction()
    {
        Debug.Log("Help");
        if (!show)
            show = true;
        else
            show = false;
    }

}
