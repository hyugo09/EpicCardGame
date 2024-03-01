using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject pauseUI;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            pauseUI.SetActive(true);
        }
    }
}
