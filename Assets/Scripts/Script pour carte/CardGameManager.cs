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
    public Transform coreStand;
    private bool firstTurn = true;
    public Transform idealrot;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject endGameUI;
    internal int CarteRestanteAPosť = 2;
    // Start is called before the first frame update
    void Start()
    {
        DoDeck();

        Button tempButton = endGameUI.GetComponentInChildren<Button>();
        tempButton.onClick.AddListener(GameObject.FindFirstObjectByType<AiInfo>().DestroyThisObject);
        tempButton.onClick.AddListener(GameObject.FindFirstObjectByType<PlayerInfo>().DestroyNextLoad);
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
        CarteRestanteAPosť = 2;
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



        CardAttackReset();
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
        else if (playerHand.cards.Count == 9)
        {
            GameObject tCard = playerHand.cards[0];
            playerHand.RemoveCard(tCard);
            playerDiscard.SendCard(tCard);
            playerHand.cards.Add(playerDeck.deck.Pop());
        }
        else
            playerHand.cards.Add(playerDeck.deck.Pop());

    }
    public void Abandon()
    {
        PlayerInfo playerInfo = GameObject.FindAnyObjectByType<PlayerInfo>().GetComponent<PlayerInfo>();
        playerInfo.gamejouer++;
        endGameUI.SetActive(true);
        endGameUI.GetComponentInChildren<TextMeshProUGUI>().text = "Yo come on la, t'aurait put continuer";
        playerInfo.derniereGameW = false;
    }
    internal void LoseGame()
    {
        //rappelle de faire un game over, probablement besoin d'un report pour aller dans l'autre scenen aussi
        PlayerInfo playerInfo = GameObject.FindAnyObjectByType<PlayerInfo>().GetComponent<PlayerInfo>();
        playerInfo.gamejouer++;
        endGameUI.SetActive(true);
        if (isAi)
        {
            endGameUI.GetComponentInChildren<TextMeshProUGUI>().text = "GG's BRO !!!!";
            playerInfo.derniereGameW = true;
            //activer l'ecran qui montre la w
        }
        else
        {

            endGameUI.GetComponentInChildren<TextMeshProUGUI>().text = "L+RATIO";
            playerInfo.derniereGameW = false;
            //activer ecran qui montre le L+ratio
        }
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
