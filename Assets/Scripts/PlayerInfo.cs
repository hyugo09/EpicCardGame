using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public CardMenu[] PlayerDeck;
    public List<int> coreDirections = new List<int>();
    public int corePV = 40;
    public int gamejouer = 0;
    public bool derniereGameW;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        //jsp pas pk cette ligne est la donc je vais la mettre en commentaire
        //FindAnyObjectByType(typeof(PlayerInfo));
    }
    
    public void DestroyNextLoad()
    {
            SceneManager.sceneLoaded += GiveAndDestroy;      
    }
     private void GiveAndDestroy(Scene scene, LoadSceneMode mode)
    {
        var temp = GameObject.FindObjectsByType<PlayerInfo>(FindObjectsSortMode.None);
        foreach(PlayerInfo pi in temp)
        if (pi != this)
        {
            SceneManager.sceneLoaded -= GiveAndDestroy;
                pi.PlayerDeck = PlayerDeck;
                pi.coreDirections = coreDirections;
                pi.corePV = corePV;
                pi.gamejouer = gamejouer;
                pi.derniereGameW = derniereGameW;
            Destroy(gameObject);
        }
    }
}
