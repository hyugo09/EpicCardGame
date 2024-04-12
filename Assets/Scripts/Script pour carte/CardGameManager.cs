using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CardGameManager : MonoBehaviour
{
    public UnityEvent DrawPhase;
    public UnityEvent MainPhase;
    public UnityEvent BattlePhase;
    public UnityEvent EndPhase;
    internal enum Phase
    {
        draw,
        main,
        battle,
        end,
        ennemy,
    }
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI text;
    public GameObject selected = null;
    [SerializeField] internal Phase currentPhase = Phase.ennemy;
    internal Vector3 originalposSelected;
    [SerializeField] internal main playerHand;
    public CardGameManager enemyGameManager;
    public GameObject Core;
    internal int corePos = 5;
    public bool isAi;
    [SerializeField] internal Field[] allField;
    [SerializeField] internal Deck playerDeck;
    [SerializeField] internal Discard playerDiscard;
    [SerializeField] private CardGameManager EnemyManager;
    private bool firstTurn = true;
    // Start is called before the first frame update
    void Start()
    {
      DoDeck();

    }
    public void DoDeck()
    {
        CardData datat = FindFirstObjectByType(typeof(CardData)).GetComponent<CardData>();
        if (isAi)
        {
            playerDeck.ShuffleDeck(datat.tempAi);
            Core = datat.tAiCore;
        }
        else
        {
            playerDeck.ShuffleDeck(datat.tempPlayer);
            Core = datat.tPlayerCore;
        }
    }
    private void Awake()
    {
        text = button.GetComponentInChildren<TextMeshProUGUI>();

    }

    public void FirstPhase()
    {
        DrawCard();
        DrawCard();
        DrawCard();
        DrawCard();
        DrawCard();


    }
    public void ChangeCurrentPhase()
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
        if (firstTurn)
        {
            FirstPhase();
        }
        else
        {
            DrawCard();
        }
        currentPhase = Phase.draw;
        if (!isAi)
        {
            text.text = "Draw Phase";
        }
        this.ChangeCurrentPhase();
    }
    private void ChangeToMain()
    {
        
        currentPhase = Phase.main;

        if (isAi)
        {
            Debug.Log("main");
            MainPhase.Invoke();
            this.ChangeCurrentPhase();
        }
        else
        {
            text.text = "Main Phase";
        }
        if (text != null)
        {
            text.text = "Main Phase";
        }
        
        
    }
    private void ChangeToBattle()
    {

        currentPhase = Phase.battle;
        if (!isAi)
        { text.text = "battle phase"; }
        if (text != null)
        {
            text.text = "battle phase";
        }
        
        if (isAi && !firstTurn)
        {
            Debug.Log("battle");
            BattlePhase.Invoke();
            this.ChangeCurrentPhase();
            
        }
        if (firstTurn)
        {
            this.ChangeCurrentPhase();
        }




    }
    private void ChangeToEnd()
    {
        if (firstTurn)
        {
            firstTurn = false;
        }
        currentPhase = Phase.end;

        if (!isAi)
        { text.text = "End Phase"; }
       
        
        this.ChangeCurrentPhase();
    }
    private void ChangeToEnnemy()
    {
        currentPhase = Phase.ennemy;
        if (!isAi)
            text.text = "Ennemy's turn";
        EnemyManager.ChangeCurrentPhase();
    }
    private void DrawCard()
    {
        if (playerDeck.deck.Count == 0)
        {
            LoseGame();
        }
        else
            playerHand.cards.Add(playerDeck.deck.Pop());

    }
    internal void LoseGame()
    {
        //rappelle de faire un game over, probablement besoin d'un report pour aller dans l'autre scenen aussi
        Debug.Log("un joueur a perdu");
    }
    private void CardAttackReset()
    {
        foreach (Field f in allField)
        {
            if (f.carteSurField != null)
            {
                f.carteSurField.canAttack = true;
            }
        }
    }
}
