using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CardPlayer : MonoBehaviour
{
    public GameObject selected = null;
    internal Vector3 originalposSelected;
    public GameObject cardPrefab;
    public int[] deck;
    public GameObject[] monsterDeck;
    public GameObject[] eventDeck;
    public GameObject[] terrainPosition;
    public GameObject[] terrainCard;
    public GameObject[] hand;
    public GameObject[] discardDeck;
    public GameObject discardCard;

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
            Card cardtemp = monsterDeck[i].GetComponent<Card>(); 
            cardtemp.goPlayer = this.gameObject;
            cardtemp.cpPlayer = this;
            i++;
        }
    }
   


}
