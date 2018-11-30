using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public interface IInvoker
{
    void setCommand(ICommand cmd);
    void invoke();
}
