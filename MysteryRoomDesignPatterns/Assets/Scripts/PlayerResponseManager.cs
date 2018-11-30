using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class PlayerResponseManager : MonoBehaviour, IPlayerResponseSubject
{
    private List<IPlayerResponseObserver> observers = new List<IPlayerResponseObserver>(); 
    private Scene currentScene;
    private IDictionary<string, string> answerKeys = new Dictionary<string, string>()
                                            {
                                                {"LivingRoom","AButton"},
                                                {"Kitchen", "AButton"},
                                                {"Bedroom","AButton"},
                                                {"Traffic","AButton"},
                                                {"MusicPlayer", "AButton"},
                                                {"CarHeadlights","AButton"},
                                                {"Adapter Hall","AButton"}
                                            };



    private IDictionary<string, bool> updateSceneKeys = new Dictionary<string, bool>()
                                            {
                                                {"LivingRoom",false},
                                                {"Kitchen", false},
                                                {"Bedroom",false},
                                                {"Traffic",false},
                                                {"MusicPlayer", false},
                                                {"CarHeadlights",false},
                                                {"Adapter Hall",false}
                                            };

    // Use this for initialization
    void Start()
    {
       
    }

    public void attach(IPlayerResponseObserver obs)
    {
        observers.Add(obs);

    }

    public void detach(IPlayerResponseObserver obs)
    {
        if (observers.Contains(obs))
            observers.Remove(obs);
    }

    public void notifyObservers()
    {
        currentScene = SceneManager.GetActiveScene();
        if (!updateSceneKeys[currentScene.name])
        {
            updateSceneKeys[currentScene.name] = true;
            foreach (var obs in observers)
            { obs.updateStatus(); Debug.Log("Calling Observer"); }


        }
    }



    

    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene();

        if (EventSystem.current.currentSelectedGameObject != null)
        {
            if (EventSystem.current.currentSelectedGameObject.name == answerKeys[currentScene.name])
            {
                notifyObservers();
            }
        }

    }
}
