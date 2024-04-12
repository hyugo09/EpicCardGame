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
    [SerializeField] private CardGameManager playerManager;
    [SerializeField] private CardGameManager aiManager;
    private void Awake()
    {
        PlayerInfo playerInfo = FindFirstObjectByType<PlayerInfo>().GetComponent<PlayerInfo>();
        AiInfo aiInfo = FindFirstObjectByType<AiInfo>().GetComponent<AiInfo>();
        int[] temp = playerInfo.PlayerDeck;
        tempPlayer = new GameObject[temp.Length];
        while (!Verif(tempPlayer))
        {
            for (int i = 0; i < temp.Length; i++)
            {
                if (tempPlayer[i] != null)
                {
                    tempPlayer[i] = null;
                }

            }

            for (int i = 0; i < temp.Length; i++)
            {
                tempPlayer[i] = Instantiate(Database[temp[i]], new Vector3(0, 0, 0), Quaternion.identity);
                tempPlayer[i].GetComponent<Card>().manager = playerManager;
            }
        }
        //tPlayerCore = Database[playerInfo.PlayerCore];
        //Core core =  Instantiate(tPlayerCore).GetComponent<Core>();
        // core.Carte.manager = playerManager;
        temp = aiInfo.AiDeck;
        tempAi = new GameObject[temp.Length];
        while (!Verif(tempAi))
        {
            for (int i = 0; i < temp.Length; i++)
            {
                if (tempAi[i] == null)
                {
                    tempAi[i] = null;
                }
            }

            for (int i = 0; i < temp.Length; i++)
            {
                tempAi[i] = Instantiate(Database[temp[i]], new Vector3(0, 0, 0), Quaternion.identity);
                tempAi[i].GetComponent<Card>().manager = aiManager;
            }
        }
        tAiCore = Database[aiInfo.aiCore];
        //core = Instantiate(tAiCore).GetComponent<Core>();
        // core.Carte.manager = aiManager;

    }

    private bool Verif(GameObject[] Deck)
    {
        for (int i = 0; i < Deck.Length; i++)
        {
            if (Deck[i] == null)
            {
                return false;
            }

        }
        return true;
    }
}
