using Cinemachine;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseUI;
    Scene currentScene;

    private void FixedUpdate()
    {
        currentScene = SceneManager.GetActiveScene();
        if (InputManager.escapeInput)
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pauseUI.SetActive(false);

        switch (currentScene.name) //switch pour gérer le curseur lorsqu'on résume la partie
        {
            case "Scene test":
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                break;
            case "CardFieldScene":
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;         
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        pauseUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    public void LoadSceneAsync(string sceneName)
    {
        StartCoroutine(LoadSceneAndResume(sceneName));
    }

    private IEnumerator LoadSceneAndResume(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        ResumeGame();
    }

    public void CardField()
    {
        LoadSceneAsync("CardFieldScene");
    }

    public void PlayGame()
    {
        LoadSceneAsync("Scene test");
    }

    public void LeaveGame()
    {
        LoadSceneAsync("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public bool isPaused { get; private set; } = false;
}
