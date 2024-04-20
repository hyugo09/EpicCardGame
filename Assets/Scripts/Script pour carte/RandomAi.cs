using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            int nbtry = 0;
            Card temp = gameManager.playerHand.cards[Random.Range(0, gameManager.playerHand.cards.Count)].GetComponent<Card>();
            while (!temp.cardonfield)
            {
                if (nbtry > 20)
                {
                    break;
                }
                // temp = gameManager.playerHand.cards[Random.Range(0, gameManager.playerHand.cards.Count)].GetComponent<Card>();
                nbtry++;
                if (temp != null)
                {

                    for (int i = 0; i < gameManager.allField.Length; i++)
                    {
                        if (gameManager.allField[i].carteSurField != null)
                        {
                            if (i == 0) // field1
                            {
                                foreach (int dir in temp.direction)
                                {
                                    if (dir == 2)// fleche du haut (8)
                                    {
                                        if (gameManager.allField[i].carteSurField.direction.Contains(8))
                                        {
                                            if (gameManager.allField[3].carteSurField == null)
                                            {
                                                gameManager.playerHand.cards.Remove(temp.gameObject);
                                                gameManager.allField[3].JouerCarte(temp);
                                                break;
                                            }
                                        }
                                    }
                                    if (dir == 4) // fleche de droite (6)
                                    {
                                        if (gameManager.allField[i].carteSurField.direction.Contains(6))
                                        {
                                            if (gameManager.allField[1].carteSurField == null)
                                            {
                                                gameManager.playerHand.cards.Remove(temp.gameObject);
                                                gameManager.allField[1].JouerCarte(temp);
                                                break;
                                            }
                                        }
                                    }
                                    if (dir == 1) // fleche de haut-droite (9)
                                    {
                                        if (gameManager.allField[i].carteSurField.direction.Contains(9))
                                        {
                                            if (gameManager.allField[4].carteSurField == null)
                                            {
                                                gameManager.playerHand.cards.Remove(temp.gameObject);
                                                gameManager.allField[4].JouerCarte(temp);
                                                break;
                                            }
                                        }
                                    }
                                }

                            }// field1
                            if (i == 1)
                            {
                                foreach (int dir in temp.direction)
                                {
                                    if (dir == 4)// fleche de droite (6)
                                    {
                                        if (gameManager.allField[i].carteSurField.direction.Contains(6))
                                        {
                                            if (gameManager.allField[2].carteSurField == null)
                                            {
                                                gameManager.playerHand.cards.Remove(temp.gameObject);
                                                gameManager.allField[2].JouerCarte(temp);
                                                break;
                                            }
                                        }
                                    }
                                    if (dir == 6) // fleche de gauche (4)
                                    {
                                        if (gameManager.allField[i].carteSurField.direction.Contains(4))
                                        {
                                            if (gameManager.allField[0].carteSurField == null)
                                            {
                                                gameManager.playerHand.cards.Remove(temp.gameObject);
                                                gameManager.allField[0].JouerCarte(temp);
                                                break;
                                            }
                                        }
                                    }
                                    if (dir == 2) // fleche de haut (8)
                                    {
                                        if (gameManager.allField[i].carteSurField.direction.Contains(8))
                                        {
                                            if (gameManager.allField[4].carteSurField == null)
                                            {
                                                gameManager.playerHand.cards.Remove(temp.gameObject);
                                                gameManager.allField[4].JouerCarte(temp);
                                                break;
                                            }
                                        }
                                    }
                                }
                            }// field2
                            if (i == 2)
                            {
                                foreach (int dir in temp.direction)
                                {
                                    if (dir == 2)// fleche du haut (8)
                                    {
                                        if (gameManager.allField[i].carteSurField.direction.Contains(8))
                                        {
                                            if (gameManager.allField[5].carteSurField == null)
                                            {
                                                gameManager.playerHand.cards.Remove(temp.gameObject);
                                                gameManager.allField[5].JouerCarte(temp);
                                                break;
                                            }
                                        }
                                    }
                                    if (dir == 6) // fleche de gauche (4)
                                    {
                                        if (gameManager.allField[i].carteSurField.direction.Contains(4))
                                        {
                                            if (gameManager.allField[1].carteSurField == null)
                                            {
                                                gameManager.playerHand.cards.Remove(temp.gameObject);
                                                gameManager.allField[1].JouerCarte(temp);
                                                break;
                                            }
                                        }
                                    }
                                    if (dir == 3) // fleche de haut-gauche (7)
                                    {
                                        if (gameManager.allField[i].carteSurField.direction.Contains(7))
                                        {
                                            if (gameManager.allField[4].carteSurField == null)
                                            {
                                                gameManager.playerHand.cards.Remove(temp.gameObject);
                                                gameManager.allField[4].JouerCarte(temp);
                                                break;
                                            }
                                        }
                                    }
                                }

                            }// field3
                            if (i == 3)
                            {
                                foreach (int dir in temp.direction)
                                {
                                    if (dir == 2)// fleche du haut (8)
                                    {
                                        if (gameManager.allField[i].carteSurField.direction.Contains(8))
                                        {
                                            if (gameManager.allField[6].carteSurField == null)
                                            {
                                                gameManager.playerHand.cards.Remove(temp.gameObject);
                                                gameManager.allField[6].JouerCarte(temp);
                                                break;
                                            }
                                        }
                                    }
                                    if (dir == 4) // fleche de droite (6)
                                    {
                                        if (gameManager.allField[i].carteSurField.direction.Contains(6))
                                        {
                                            if (gameManager.allField[4].carteSurField == null)
                                            {
                                                gameManager.playerHand.cards.Remove(temp.gameObject);
                                                gameManager.allField[4].JouerCarte(temp);
                                                break;
                                            }
                                        }
                                    }
                                    if (dir == 8)// fleche du bas (2)
                                    {
                                        if (gameManager.allField[i].carteSurField.direction.Contains(8))
                                        {
                                            if (gameManager.allField[0].carteSurField == null)
                                            {
                                                gameManager.playerHand.cards.Remove(temp.gameObject);
                                                gameManager.allField[0].JouerCarte(temp);
                                                break;
                                            }
                                        }
                                    }




                                }
                            }// field4
                            if (i == 4)
                            {

                                foreach (int dir in temp.direction)
                                {
                                    if (dir == 2)// fleche du haut (8)
                                    {
                                        if (gameManager.allField[i].carteSurField.direction.Contains(8))
                                        {
                                            if (gameManager.allField[7].carteSurField == null)
                                            {
                                                gameManager.playerHand.cards.Remove(temp.gameObject);
                                                gameManager.allField[7].JouerCarte(temp);
                                                break;
                                            }
                                        }
                                    }
                                    if (dir == 4) // fleche de droite (6)
                                    {
                                        if (gameManager.allField[i].carteSurField.direction.Contains(6))
                                        {
                                            if (gameManager.allField[3].carteSurField == null)
                                            {
                                                gameManager.playerHand.cards.Remove(temp.gameObject);
                                                gameManager.allField[3].JouerCarte(temp);
                                                break;
                                            }
                                        }
                                    }
                                    if (dir == 1) // fleche de haut-droite (9)
                                    {
                                        if (gameManager.allField[i].carteSurField.direction.Contains(9))
                                        {
                                            if (gameManager.allField[8].carteSurField == null)
                                            {
                                                gameManager.playerHand.cards.Remove(temp.gameObject);
                                                gameManager.allField[8].JouerCarte(temp);
                                                break;
                                            }
                                        }
                                    }
                                    if (dir == 6) // fleche de gauche (4)
                                    {
                                        if (gameManager.allField[i].carteSurField.direction.Contains(4))
                                        {
                                            if (gameManager.allField[3].carteSurField == null)
                                            {
                                                gameManager.playerHand.cards.Remove(temp.gameObject);
                                                gameManager.allField[3].JouerCarte(temp);
                                                break;
                                            }
                                        }
                                    }
                                    if (dir == 3) // fleche de haut-gauche (7)
                                    {
                                        if (gameManager.allField[i].carteSurField.direction.Contains(7))
                                        {
                                            if (gameManager.allField[6].carteSurField == null)
                                            {
                                                gameManager.playerHand.cards.Remove(temp.gameObject);
                                                gameManager.allField[6].JouerCarte(temp);
                                                break;
                                            }
                                        }
                                    }
                                    if (dir == 7) // fleche de bas-gauche (3)
                                    {
                                        if (gameManager.allField[i].carteSurField.direction.Contains(3))
                                        {
                                            if (gameManager.allField[2].carteSurField == null)
                                            {
                                                gameManager.playerHand.cards.Remove(temp.gameObject);
                                                gameManager.allField[2].JouerCarte(temp);
                                                break;
                                            }
                                        }
                                    }
                                    if (dir == 8)// fleche du bas (2)
                                    {
                                        if (gameManager.allField[i].carteSurField.direction.Contains(2))
                                        {
                                            if (gameManager.allField[1].carteSurField == null)
                                            {
                                                gameManager.playerHand.cards.Remove(temp.gameObject);
                                                gameManager.allField[1].JouerCarte(temp);
                                                break;
                                            }
                                        }
                                    }
                                    if (dir == 9) // fleche de haut-droite (1)
                                    {
                                        if (gameManager.allField[i].carteSurField.direction.Contains(1))
                                        {
                                            if (gameManager.allField[0].carteSurField == null)
                                            {
                                                gameManager.playerHand.cards.Remove(temp.gameObject);
                                                gameManager.allField[0].JouerCarte(temp);
                                                break;
                                            }
                                        }
                                    }


                                }


                            }// field5
                            if (i == 5)
                            {
                                foreach (int dir in temp.direction)
                                {
                                    if (dir == 2)// fleche du haut (8)
                                    {
                                        if (gameManager.allField[i].carteSurField.direction.Contains(8))
                                        {
                                            if (gameManager.allField[8].carteSurField == null)
                                            {
                                                gameManager.playerHand.cards.Remove(temp.gameObject);
                                                gameManager.allField[8].JouerCarte(temp);
                                                break;
                                            }
                                        }
                                    }
                                    if (dir == 6) // fleche de gauche (4)
                                    {
                                        if (gameManager.allField[i].carteSurField.direction.Contains(4))
                                        {
                                            if (gameManager.allField[4].carteSurField == null)
                                            {
                                                gameManager.playerHand.cards.Remove(temp.gameObject);
                                                gameManager.allField[4].JouerCarte(temp);
                                                break;
                                            }
                                        }
                                    }
                                    if (dir == 8)// fleche du bas (2)
                                    {
                                        if (gameManager.allField[i].carteSurField.direction.Contains(8))
                                        {
                                            if (gameManager.allField[2].carteSurField == null)
                                            {
                                                gameManager.playerHand.cards.Remove(temp.gameObject);
                                                gameManager.allField[2].JouerCarte(temp);
                                                break;
                                            }
                                        }
                                    }




                                }
                            }// field6
                            if (i == 6) // field7
                            {
                                foreach (int dir in temp.direction)
                                {
                                    if (dir == 8)// fleche du bas (2)
                                    {
                                        if (gameManager.allField[i].carteSurField.direction.Contains(2))
                                        {
                                            if (gameManager.allField[3].carteSurField == null)
                                            {
                                                gameManager.playerHand.cards.Remove(temp.gameObject);
                                                gameManager.allField[3].JouerCarte(temp);
                                                break;
                                            }
                                        }
                                    }
                                    if (dir == 4) // fleche de droite (6)
                                    {
                                        if (gameManager.allField[i].carteSurField.direction.Contains(6))
                                        {
                                            if (gameManager.allField[7].carteSurField == null)
                                            {
                                                gameManager.playerHand.cards.Remove(temp.gameObject);
                                                gameManager.allField[7].JouerCarte(temp);
                                                break;
                                            }
                                        }
                                    }
                                    if (dir == 3) // fleche de haut-droite (7)
                                    {
                                        if (gameManager.allField[i].carteSurField.direction.Contains(7))
                                        {
                                            if (gameManager.allField[4].carteSurField == null)
                                            {
                                                gameManager.playerHand.cards.Remove(temp.gameObject);
                                                gameManager.allField[4].JouerCarte(temp);
                                                break;
                                            }
                                        }
                                    }
                                }

                            }// field7
                            if (i == 7)
                            {
                                foreach (int dir in temp.direction)
                                {
                                    if (dir == 4)// fleche de droite (6)
                                    {
                                        if (gameManager.allField[i].carteSurField.direction.Contains(6))
                                        {
                                            if (gameManager.allField[8].carteSurField == null)
                                            {
                                                gameManager.playerHand.cards.Remove(temp.gameObject);
                                                gameManager.allField[8].JouerCarte(temp);
                                                break;
                                            }
                                        }
                                    }
                                    if (dir == 6) // fleche de gauche (4)
                                    {
                                        if (gameManager.allField[i].carteSurField.direction.Contains(4))
                                        {
                                            if (gameManager.allField[6].carteSurField == null)
                                            {
                                                gameManager.playerHand.cards.Remove(temp.gameObject);
                                                gameManager.allField[6].JouerCarte(temp);
                                                break;
                                            }
                                        }
                                    }
                                    if (dir == 8) // fleche de bas (2)
                                    {
                                        if (gameManager.allField[i].carteSurField.direction.Contains(2))
                                        {
                                            if (gameManager.allField[4].carteSurField == null)
                                            {
                                                gameManager.playerHand.cards.Remove(temp.gameObject);
                                                gameManager.allField[4].JouerCarte(temp);
                                                break;
                                            }
                                        }
                                    }
                                }
                            }// field8
                            if (i == 8)
                            {
                                foreach (int dir in temp.direction)
                                {
                                    if (dir == 8)// fleche du bas (2)
                                    {
                                        if (gameManager.allField[i].carteSurField.direction.Contains(2))
                                        {
                                            if (gameManager.allField[5].carteSurField == null)
                                            {
                                                gameManager.playerHand.cards.Remove(temp.gameObject);
                                                gameManager.allField[5].JouerCarte(temp);
                                                break;
                                            }
                                        }
                                    }
                                    if (dir == 6) // fleche de gauche (4)
                                    {
                                        if (gameManager.allField[i].carteSurField.direction.Contains(4))
                                        {
                                            if (gameManager.allField[7].carteSurField == null)
                                            {
                                                gameManager.playerHand.cards.Remove(temp.gameObject);
                                                gameManager.allField[7].JouerCarte(temp);
                                                break;
                                            }
                                        }
                                    }
                                    if (dir == 9) // fleche de haut-droite (1)
                                    {
                                        if (gameManager.allField[i].carteSurField.direction.Contains(1))
                                        {
                                            if (gameManager.allField[4].carteSurField == null)
                                            {
                                                gameManager.playerHand.cards.Remove(temp.gameObject);
                                                gameManager.allField[4].JouerCarte(temp);
                                                break;
                                            }
                                        }
                                    }
                                }

                            }// field 9
                        }


                        gameManager.playerHand.cards.Remove(temp.gameObject);
                    }


                }
            }
            
        }
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
        for (int i = 0; i < attackCards.Count; i++)
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


