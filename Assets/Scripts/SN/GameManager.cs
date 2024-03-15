using Cinemachine;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseUI;
    
    private void Update()
    {
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
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

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
