using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardData : MonoBehaviour
{
    public GameObject[] Database;
     internal GameObject[] tempPlayer;
    internal GameObject[] tempAi;
    internal GameObject tAiCore;
    internal GameObject tPlayerCore;
    private void Awake()
    {
        PlayerInfo playerInfo = FindFirstObjectByType<PlayerInfo>().GetComponent<PlayerInfo>();
        AiInfo aiInfo = FindFirstObjectByType<AiInfo>().GetComponent<AiInfo>();
        int[] temp = playerInfo.PlayerDeck;
         tempPlayer = new GameObject[temp.Length];
        for (int i = 0; i < temp.Length; i++)
        {
            tempPlayer[i] = Instantiate(Database[temp[i]],new Vector3(0,0,0), Quaternion.identity);
            //tempPlayer[i].GetComponent<Card>().manager = le manager du joueur, doit parler a gameryan
        }
        tPlayerCore = Database[playerInfo.PlayerCore];
        Instantiate(tPlayerCore);
        temp = aiInfo.AiDeck;
        tempAi = new GameObject[temp.Length];
        for (int i = 0; i < temp.Length; i++)
        {
            tempAi[i] = Instantiate(Database[temp[i]], new Vector3(0, 0, 0), Quaternion.identity);
        }
        tAiCore = Database[aiInfo.aiCore];
        Instantiate (tAiCore);

    }
}
