using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardData : MonoBehaviour
{
    public GameObject[] Database;
     internal GameObject[] tempd;
    private void Awake()
    {
        PlayerInfo playerInfo = FindFirstObjectByType<PlayerInfo>().GetComponent<PlayerInfo>();

        int[] temp = playerInfo.PlayerDeck;
         tempd = new GameObject[temp.Length];
        for (int i = 0; i < temp.Length; i++)
        {
            tempd[i] = Instantiate(Database[temp[i]],new Vector3(0,0,0), Quaternion.identity);
        }
        
    }
}
