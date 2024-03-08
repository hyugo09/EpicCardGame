using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardGameManager : MonoBehaviour
{
    internal enum Phase
    {
        draw,
        main,
        battle,
        end,
        ennemy,
    }

    public GameObject selected = null;
    [SerializeField] internal Phase currentPhase;
    internal Vector3 originalposSelected;
    [SerializeField] internal main playerHand;
    public CardGameManager enemyGameManager;
    public bool isAi;
    [SerializeField] Field[] allField;
    [SerializeField] internal Deck playerDeck;
    [SerializeField] internal Discard playerDiscard;
    [SerializeField] private CardGameManager EnemyManager;
    // Start is called before the first frame update
    void Start()
    {
        CardData datat = FindFirstObjectByType(typeof(CardData)).GetComponent<CardData>();
        playerDeck.ShuffleDeck(datat.tempd);
    }
    private void Awake()
    {
       
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void ChangeCurrentPhase()
    {
        switch (currentPhase)
        {
            case Phase.draw:
                {
                    ChangeToMain();
                    break;
                }
            case Phase.main:
                {
                    ChangeToBattle();
                    break;
                }
            case Phase.battle:
                {
                    ChangeToEnd();
                    break;
                }
            case Phase.end:
                {
                    ChangeToEnnemy();
                    break;
                }
            case Phase.ennemy:
                {
                    ChangeToDraw();
                    break;
                }

        }
    }
    private void ChangeToDraw()
    {
        currentPhase = Phase.draw;
        DrawCard();
        ChangeCurrentPhase();
    }
    private void ChangeToMain()
    {
        
        currentPhase = Phase.main;
        if (isAi)
        {
            Playcard();
            Playcard();
            ChangeCurrentPhase();
        }
    }
    private void ChangeToBattle()
    {
        currentPhase = Phase.battle;
    }
    private void ChangeToEnd()
    {
        currentPhase = Phase.end;
        enemyGameManager.ChangeCurrentPhase();
        ChangeCurrentPhase();
    }
    private void ChangeToEnnemy()
    {
        currentPhase = Phase.ennemy;
    }
    private void DrawCard()
    {
        if (playerDeck.deck.Peek() == null)
        {
            LoseGame();
        }
        else
            playerHand.cards.Add(playerDeck.deck.Pop());

    }
    private void LoseGame()
    {

    }
    private void Playcard()
    {
        
        
        if (playerHand.cards.Count > 0)
        {
            GameObject temp = playerHand.cards[Random.Range(0, playerHand.cards.Count)];
            if (temp != null) { 
                Field ftemp = allField[Random.Range(0,allField.Length)];
                if (ftemp.carteSurField == null)// ajouter la condition pour voir si c jouable
                {
                    //choisir un field et faire passer le meme truc de mouse down
                    
                    ftemp.JouerCarte(temp);
                    
                }
                else
                {
                    Playcard();
                }
            }
            
            
        }
    }
    private void AiAttack(int layerIndex)
    {
        
    }
}
