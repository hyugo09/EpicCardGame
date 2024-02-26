using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseUI;
    public bool isPaused = false;
    public NavMeshAgent agent;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            PauseMenu();
        }
    }

    public void PauseMenu()
    {
        if (isPaused)
        {
            ResumeGame();
        } else
        {
            PauseGame();
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pauseUI.SetActive(false);
        //GetComponent<NavMeshAgent>().isStopped = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        pauseUI.SetActive(true);
        //GetComponent<NavMeshAgent>().isStopped = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LeaveGame()
    {
        //Quitter CardFieldScene
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Game(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void PlayGame()
    {
        Game("Scene test");
    }

    public void CardField(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void CardFieldScene()
    {
        CardField("CardFieldScene");
    }

    public void MainMenu(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public void MainMenuScene()
    {
        MainMenu("MainMenu");
    }
}
