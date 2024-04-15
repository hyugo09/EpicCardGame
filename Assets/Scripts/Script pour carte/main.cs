using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    
    public List<GameObject> cards = new List<GameObject>();
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ArrangeHand();
    }
    public void AddCards(GameObject card)
    {// va etre appeler par le deck pour piocher

        cards.Add(card);
        card.transform.SetParent(transform);
        ArrangeHand();
        
    }
    public void RemoveCard(GameObject card)
    {// est appeler pour le field ou la carte elle meme
        
        cards.Remove(card);

        
        card.transform.SetParent(null);

        
        ArrangeHand();
    }
    private void ArrangeHand()
    {
        float cardWidth = 3.5f; 
        float spacing = 2.5f; 

        
        float totalWidth = (cardWidth + spacing) * cards.Count - spacing;

        
        float startX = -totalWidth / 2.0f;

        
        for (int i = 0; i < cards.Count; i++)
        {
            if (cards[i] != null)
            {
                cards[i].transform.SetParent(transform);
                // Calculate position for the current card
                float xPos = startX + i * (cardWidth + spacing);

                // Set the position of the card
                Vector3 newPosition = transform.position + new Vector3(xPos, 0f, 0f);
                
                cards[i].transform.position = newPosition;
                cards[i].transform.rotation = this.transform.rotation;
            }
            
        }
    }
}
