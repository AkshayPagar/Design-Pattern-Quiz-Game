using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositeGameScreen :IDisplayComponent
{
    private List<IDisplayComponent> components = new List<IDisplayComponent>();

    public void display() {
        foreach(IDisplayComponent c in components) {
            Debug.Log(c);
            c.display();
        }
 
    }
    public void addSubComponent(IDisplayComponent c) {
        components.Add(c);
    }

    void Start() {
    }

    void Update() {
    }
}
