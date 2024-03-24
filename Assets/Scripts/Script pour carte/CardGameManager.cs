using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI text;
    public GameObject selected = null;
    [SerializeField] internal Phase currentPhase;
    internal Vector3 originalposSelected;
    [SerializeField] internal main playerHand;
    public CardGameManager enemyGameManager;
    public bool isAi;
    [SerializeField] Lien[] allLink;
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
        text.text = "Main Phase";
        if (isAi)
        {
            text.text = "Ennemie Main";
            Playcard();
            Playcard();
            ChangeCurrentPhase();
        }
    }
    private void ChangeToBattle()
    {
        currentPhase = Phase.battle;
        
        text.text = "battle phase";
        if (isAi) { AiAttack();
        }
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
    private void Playcard()
    {


        if (playerHand.cards.Count > 0)
        {
            GameObject temp = playerHand.cards[Random.Range(0, playerHand.cards.Count)];
            if (temp != null)
            {
                Field ftemp = allField[Random.Range(0, allField.Length)];
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
    private void AiAttack()
    {

        for (int i = 0; i < allField.Length; i++)
        {
            if (allField[i].carteSurField != null && allField[i].carteSurField.canAttack)
            {
                Card temp = allField[i].carteSurField;
                for (int j = 0; j < allField[i].liens.Length; j++)
                {
                    if (allField[i].liens[j].active)
                    {
                        allField[i].liens[j].Dommage(temp.attack);
                        break;
                    }
                }
            }
        }
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
