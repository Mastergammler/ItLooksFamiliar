using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class KeyboardListener : MonoBehaviour
{
    public void SpacePressed(CallbackContext ctx)
    {
        QuitApplication();
    }

    public void QuitApplication()
    {
        Debug.Log("Quitting application");
        Application.Quit();
    }

    public void LoadNext()
    {
        SceneLoader.Instance.LoadNext();
    }
}
