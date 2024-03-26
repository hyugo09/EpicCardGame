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
    [SerializeField] internal Phase currentPhase;
    internal Vector3 originalposSelected;
    [SerializeField] internal main playerHand;
    public CardGameManager enemyGameManager;
    public Card Core;
    internal int corePos = 5;
    public bool isAi;
    [SerializeField] Lien[] allLink;
    [SerializeField] internal Field[] allField ;
    [SerializeField] internal Deck playerDeck;
    [SerializeField] internal Discard playerDiscard;
    [SerializeField] private CardGameManager EnemyManager;
    
    // Start is called before the first frame update
    void Start()
    {
        CardData datat = FindFirstObjectByType(typeof(CardData)).GetComponent<CardData>();
        playerDeck.ShuffleDeck(datat.tempd);

        allField[corePos-1].JouerCarte(Core.gameObject);

    }
    private void Awake()
    {
        text = button.GetComponentInChildren<TextMeshProUGUI>();
        text.text = "omegalol";
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        ChangeCurrentPhase();
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
        currentPhase = Phase.draw;
        text.text = "Draw Phase";
        DrawCard();
        ChangeCurrentPhase();
    }
    private void ChangeToMain()
    {
        
        currentPhase = Phase.main;
        if (text != null)
        {
            text.text = "Main Phase";
        }
        MainPhase.Invoke();
        
    }
    private void ChangeToBattle()
    {
        currentPhase = Phase.battle;
        if (text != null)
        {
            text.text = "battle phase";
        }
        BattlePhase.Invoke();
        
        
    }
    private void ChangeToEnd()
    {
        currentPhase = Phase.end;
        text.text = "End Phase";
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
