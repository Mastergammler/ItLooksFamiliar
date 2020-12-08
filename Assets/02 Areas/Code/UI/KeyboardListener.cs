using System.Collections;
using System.Collections.Generic;
using ItLooksFamiliar.Core;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace ItLooksFamiliar.UI
{

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

}