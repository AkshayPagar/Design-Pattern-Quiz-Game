using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public interface IPlayerResponseSubject
{


    void attach(IPlayerResponseObserver obs);
    void detach(IPlayerResponseObserver obs);
    void notifyObservers();
}
