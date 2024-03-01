using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameManager : MonoBehaviour
{
    internal enum Phase
    {
        draw,
        main,
        battle,
        end,

    }

    public GameObject selected = null;
    internal Vector3 originalposSelected;
    [SerializeField] internal main playerHand;
    [SerializeField] internal Deck playerDeck;
    // Start is called before the first frame update
    void Start()
    {
        playerDeck.ShuffleDeck(find);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
