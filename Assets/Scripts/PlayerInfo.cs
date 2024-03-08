using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
   public int[] PlayerDeck = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        FindAnyObjectByType(typeof(PlayerInfo));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
