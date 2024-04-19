using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CardData : MonoBehaviour
{
    public GameObject[] Database;
    public GameObject[] CoreData;
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
        int[] temp = new int[20];
        for (int i = 0; i < temp.Length; i++)
        {
            temp[i] = playerInfo.PlayerDeck.ElementAt(i).ID;
        }
        
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
        tPlayerCore = CoreData[0];
        Core core = Instantiate(tPlayerCore).GetComponent<Core>();

        Card tcard = core.gameObject.GetComponent<Card>();
        tcard.manager = playerManager;
        tcard.direction = playerInfo.coreDirections.ToArray() ;

        if(playerInfo.corePV != 40)
        {
            tcard.direction = playerInfo.coreDirections.ToArray();
            tcard.defense = playerInfo.corePV;
        }        
        core.gameObject.transform.position = playerManager.coreStand.position;

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
        tAiCore = CoreData[0];
        core = Instantiate(tAiCore).GetComponent<Core>();
        tcard = core.gameObject.GetComponent<Card>();
        tcard.manager = aiManager;
        tcard.direction = aiInfo.aiCore;
         core.Carte.manager = aiManager;

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
