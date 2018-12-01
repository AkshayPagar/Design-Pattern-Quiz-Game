using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDisplayComponent{

    void display();
    void addSubComponent(IDisplayComponent c);
}
