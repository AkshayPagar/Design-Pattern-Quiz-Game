using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public interface ICommand
{
    void execute();
    void setReceiver(IReceiver target);
}
