using System.Collections;
using System.Collections.Generic;
using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public int[] PlayerDeck = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public List<int> coreDirections = new List<int>();
    public int corePV = 40;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        //jsp pas pk cette ligne est la donc je vais la mettre en commentaire
        //FindAnyObjectByType(typeof(PlayerInfo));
    }

    
}
