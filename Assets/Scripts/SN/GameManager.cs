using Cinemachine;
using System.Collections;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseUI;
    Scene currentScene;

    public GameObject player;
    public GameData currentGameData;
    public PlayerInteraction currentInteraction;


    private void FixedUpdate()
    {
        //currentInteraction = gameObject.GetComponent<PlayerInteraction>();
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
                if (currentInteraction.dialogueUI)
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
                else
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }
                break;
            case "Terrain":

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
        LoadSceneAsync("Terrain");
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
    public void SaveGame()
    {
        if (player == null) return; // Ensure there is a player to save

        currentGameData.currentSceneName = SceneManager.GetActiveScene().name;
        currentGameData.playerPositionX = player.transform.position.x;
        currentGameData.playerPositionY = player.transform.position.y;
        currentGameData.playerPositionZ = player.transform.position.z;
        currentGameData.playerRotationY = player.transform.eulerAngles.y;

        try
        {
            string path = Application.persistentDataPath + "/savefile.json";
            string json = JsonUtility.ToJson(currentGameData, true);
            File.WriteAllText(path, json);
            Debug.Log("Game saved successfully to: " + path);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Save failed: " + ex.Message);
        }
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            currentGameData = JsonUtility.FromJson<GameData>(json);

            SceneManager.LoadScene(currentGameData.currentSceneName);
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == currentGameData.currentSceneName)
        {
            ApplySaveGame();
        }
    }

    private void ApplySaveGame()
    {
        Vector3 position = new Vector3(currentGameData.playerPositionX, currentGameData.playerPositionY, currentGameData.playerPositionZ);
        Quaternion rotation = Quaternion.Euler(0, currentGameData.playerRotationY, 0);

        player.transform.position = position;
        player.transform.rotation = rotation;
    }
}
