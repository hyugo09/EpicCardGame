using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField]public Stack<GameObject> deck = new Stack<GameObject>();
    [SerializeField] CardGameManager gameManager;
    public List<GameObject> deckList = new List<GameObject>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShuffleDeck(GameObject[] initialDeck)
    {
        for (int i = 0; i < initialDeck.Length; i++)
        {
            GameObject temp = initialDeck[i];
            int j = Random.Range(i, initialDeck.Length);
            initialDeck[i] = initialDeck[j];
            initialDeck[j] = temp;
        }
        for (int i = 0;i < initialDeck.Length; i++) 
        {
            initialDeck[i].GetComponent<Card>().manager = gameManager;
            deck.Push(initialDeck[i]);
            deckList.Add(initialDeck[i]);
        }
        PlaceCard();

    }

    

    public void ShuffleDeck()
    {
        GameObject[] initialDeck = deck.ToArray();
        for (int i = 0; i < initialDeck.Length; i++)
        {
            GameObject temp = initialDeck[i];
            int j = Random.Range(i, initialDeck.Length);
            initialDeck[i] = initialDeck[j];
            initialDeck[j] = temp;
        }
        foreach (GameObject temp in deck)
        {
            deck.Push(temp);
        }
        PlaceCard();

    }

    private void PlaceCard()
    {
        float offset = transform.position.y;
        foreach (GameObject card in deck)
        {
            card.transform.position = new Vector3(transform.position.x,offset,transform.position.z);
            card.transform.rotation = this.gameObject.transform.rotation;
            offset += 0.03f;
        }
    }
}
