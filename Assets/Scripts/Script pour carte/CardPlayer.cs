using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CardPlayer : MonoBehaviour
{
    public GameObject cardPrefab;
    public int[] deck;
    public GameObject[] monsterDeck;
    public GameObject[] eventDeck;
    public GameObject[] terrainPosition;
    public GameObject[] terrainCard;
    public GameObject[] hand;
    public GameObject[] discardDeck;
    public GameObject discardCard;

    public int monsterDeckCount, eventDeckCount, handCount, discardCount;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitiateCard()
    {
        int i = 0;
        foreach (int card in deck)
        {
            
            GameObject temp;
            temp = Instantiate(cardPrefab, transform.position, transform.rotation);
            monsterDeck[i]= temp;
            monsterDeck[i].GetComponent<Card>().Player = this.gameObject;
            i++;
        }
    }
}
