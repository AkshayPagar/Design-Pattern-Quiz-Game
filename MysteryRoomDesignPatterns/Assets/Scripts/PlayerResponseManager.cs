using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerResponseManager : IPlayerResponseSubject
{

    private static PlayerResponseManager playerResponseManager;

    private static object obj = new object();
    
    private PlayerResponseManager()
    {
    }

    
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

    public static PlayerResponseManager GetInstance()
    {
        lock (obj)
        {
            if (playerResponseManager == null)
            {
                playerResponseManager = new PlayerResponseManager();
            }
        }

        return playerResponseManager;
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
            foreach (var obs in observers)
               obs.updateStatus(); 
        }

    public void checkAnswerKey(GameObject button)
    {
        currentScene = SceneManager.GetActiveScene();
        if (!updateSceneKeys[currentScene.name])
        {
            updateSceneKeys[currentScene.name] = true;
            if (button.name == answerKeys[currentScene.name])
                notifyObservers();
        }
    }


    public void UpdateSceneKeys()
    {
        updateSceneKeys["LivingRoom"] = false;
        updateSceneKeys["Kitchen"] = false;
        updateSceneKeys["Traffic"] = false;
        updateSceneKeys["MusicPlayer"] = false;
        updateSceneKeys["CarHeadlights"] = false;
        updateSceneKeys["Bedroom"] = false;
        updateSceneKeys["Adapter Hall"] = false;


    }

}
