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
        if (!gameManager.Core.GetComponent<Card>().cardonfield)
        {
            PlaceCore();
        }

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
                        Debug.Log("trying");
                        ftemp.JouerCarte(temp.GetComponent<Card>());
                        reussi = true;
                    }
                }
                gameManager.playerHand.cards.Remove(temp);
            }


        }
        else { return; }
    }

    public void AiAttack()
    {
            List<Card> attackCards = new List<Card>();
            List<Lien> attackable = new List<Lien>();
            foreach (Field a in gameManager.allField)
            {
                if (a.carteSurField != null)
                {
                    attackCards.Add(a.carteSurField);
                }
            }

            foreach (Field a in gameManager.enemyGameManager.allField)
            {
                foreach (Lien l in a.liens)
                {
                    if (l.active)
                    {
                        if (!attackable.Contains(l))
                        { attackable.Add(l); }
                    }
                }
            }
                for (int i =0; i < attackCards.Count; i++)
                {
                    
                    attackable[Random.Range(0, attackable.Count)].Dommage(attackCards[i].attack);
                }
            

        
    }
    public void PlaceCore()
    {
        gameManager.selected = gameManager.Core;
        gameManager.allField[4].JouerCore();
    }
}


