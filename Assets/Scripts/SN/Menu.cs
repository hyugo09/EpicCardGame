using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviour
{
    public GameObject pauseUI;

    private void Update()
    {

        if (InputManager.escapeInput && !pauseUI)
        {
            pauseUI.SetActive(true);
        }

    }
}
