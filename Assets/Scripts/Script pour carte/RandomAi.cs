using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAi : MonoBehaviour
{
    [SerializeField] CardGameManager gameManager;

    private void Start()
    {
        gameManager.isAi = true;

       
        
           gameManager.DoDeck();
        
    }
    // Update is called once per frame
    void Update()
    {
       
    }

    public void Playcard()
    {


        if (gameManager.playerHand.cards.Count > 0)
        {
            GameObject temp = gameManager.playerHand.cards[Random.Range(0, gameManager.playerHand.cards.Count)];
            if (temp != null)
            {
                bool reussi = false;
                while(reussi == false)
                {
                    Field ftemp = gameManager.allField[Random.Range(0, gameManager.allField.Length)];
                    if (ftemp.carteSurField == null)// ajouter la condition pour voir si c jouable
                    {
                        //choisir un field et faire passer le meme truc de mouse down

                        ftemp.JouerCarte(temp.GetComponent<Card>());
                        reussi = true;
                    }
                }
                
            }


        }
    }

    public void AiAttack()
    {

        for (int i = 0; i < gameManager.allField.Length; i++)
        {
            if (i != gameManager.corePos - 1)
            {
                if (gameManager.allField[i].carteSurField != null && gameManager.allField[i].carteSurField.canAttack)
                {

                    Card temp = gameManager.allField[i].carteSurField;
                    for (int j = 0; j < gameManager.allField[i].liens.Length; j++)
                    {
                        if (gameManager.allField[i].liens[j].active)
                        {
                            gameManager.allField[i].liens[j].Dommage(temp.attack);
                            break;
                        }
                    }
                }
            }
        }
    }
}
