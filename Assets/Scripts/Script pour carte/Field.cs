using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Field : MonoBehaviour
{
    Vector3 offset = new Vector3(0, -0.3f, 0.375f);
    public CardGameManager manager;
    [SerializeField] internal Card carteSurField = null;

    bool selected = false;
    public List<GameObject> listOfChildren;
    [SerializeField] private Material directionMaterial;
    public Lien[] liens;
    public int position;
    void Start()
    {
        GetChildRecursive(this.gameObject);


    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
       
        Debug.Log("selectionner");
        if (manager.selected != null && manager.selected.GetComponent<Card>() != null && manager.currentPhase == CardGameManager.Phase.main)
        {
            Debug.Log("selectionner");
            if (manager.selected != null && manager.selected.GetComponent<Card>() != null)
            {
                carteSurField = manager.selected.GetComponent<Card>(); ;
                carteSurField.cardonfield = true;
                manager.playerHand.RemoveCard(carteSurField.gameObject);
                manager.selected = null;
                carteSurField.transform.position = transform.position + offset;


                Debug.Log("je suis la");

                foreach (GameObject child in listOfChildren)
                {
                    int i = 0;
                    while (i < carteSurField.direction.Length)
                    {
                        if (child.name == carteSurField.direction[i].ToString())
                        {
                            MeshRenderer temp = child.GetComponent<MeshRenderer>();
                            temp.material = directionMaterial;

                        }
                        i++;
                    }
                }

                VerificationLien(true);

            }
        }
        else if(manager.currentPhase == CardGameManager.Phase.battle)
        {
            manager.selected = carteSurField.gameObject;
            BattleStartCameraController b = GameObject.FindFirstObjectByType<BattleStartCameraController>().GetComponent<BattleStartCameraController>();
            b.SwitchCam();
        }



    }
    private void GetChildRecursive(GameObject obj)
    {
        if (null == obj)
            return;

        foreach (Transform child in obj.transform)
        {
            if (null == child)
                continue;
            //child.gameobject contains the current child you can do whatever you want like add it to an array
            listOfChildren.Add(child.gameObject);

        }
    }

    private bool VerificationLien(bool repeat, Card Carte = null)
    {
        bool lienTrouver = false;
        if (Carte != null)
            foreach (Lien lien in liens)
            {
                for (int i = 0; i < Carte.direction.Length; i++)
                {
                    if (position != 2 || position != 5 || position != 8)
                    {


                        if (lien.gameObject.name == $"{position}-{Carte.direction[i]}")
                        {
                            Field field = null;
                            lienTrouver = true;
                            if (lien.field1 == this)
                            {
                                field = lien.field2;
                            }
                            else if (lien.field2 == this)
                            {
                                field = lien.field1;
                            }
                            else
                            {
                                break;
                            }
                            if (field.carteSurField != null)
                            {
                                for (int j = 0; j < field.carteSurField.direction.Length; j++)
                                {
                                    switch (field.carteSurField.direction[j])
                                    {
                                        case 1:
                                            {
                                                if (Carte.direction[i] == 9)
                                                {
                                                    lienTrouver = true;
                                                    //lien.gameObject.SetActive(true);
                                                    lien.setLienPV();
                                                }
                                                break;
                                            }
                                        case 2:
                                            {
                                                if (Carte.direction[i] == 8)
                                                {
                                                    lienTrouver = true;
                                                    //lien.gameObject.SetActive(true);
                                                    lien.setLienPV();
                                                }
                                                break;
                                            }
                                        case 3:
                                            {
                                                if (Carte.direction[i] == 7)
                                                {
                                                    lienTrouver = true;
                                                    //lien.gameObject.SetActive(true);
                                                    lien.setLienPV();
                                                }
                                                break;
                                            }
                                        case 4:
                                            {
                                                if (Carte.direction[i] == 6)
                                                {
                                                    lienTrouver = true;
                                                    //lien.gameObject.SetActive(true);
                                                    lien.setLienPV();
                                                }
                                                break;
                                            }
                                        case 6:
                                            {
                                                if (Carte.direction[i] == 4)
                                                {
                                                    lienTrouver = true;
                                                    //lien.gameObject.SetActive(true);
                                                    lien.setLienPV();
                                                }
                                                break;
                                            }
                                        case 7:
                                            {
                                                if (Carte.direction[i] == 3)
                                                {
                                                    lienTrouver = true;
                                                    //lien.gameObject.SetActive(true);
                                                    lien.setLienPV();
                                                }
                                                break;
                                            }
                                        case 8:
                                            {
                                                if (Carte.direction[i] == 2)
                                                {
                                                    lienTrouver = true;
                                                    //lien.gameObject.SetActive(true);
                                                    lien.setLienPV();
                                                }
                                                break;
                                            }
                                        case 9:
                                            {
                                                if (Carte.direction[i] == 1)
                                                {
                                                    lienTrouver = true;
                                                    //lien.gameObject.SetActive(true);
                                                    lien.setLienPV();
                                                }
                                                break;
                                            }
                                        default:
                                            {
                                                Debug.Log("recherche lien echouer");
                                                break;
                                            }
                                    }
                                }
                            }
                        }
                        // apres if (lien.gameObject.name == $"{position}-{Carte.direction[i]}") 

                    }
                    else if (Carte.direction[i] == 2 || Carte.direction[i] == 8)
                    {

                    }

                }
                //apres for i
                if (lienTrouver == false && repeat)
                {
                    Field field = null;

                    if (lien.field1 == this)
                    {
                        field = lien.field2;
                    }
                    else if (lien.field2 == this)
                    {
                        field = lien.field1;
                    }
                    else
                    {
                        return lienTrouver;
                    }

                    if (field != null)
                    {
                        carteSurField = Carte;
                        return field.VerificationLien(false, field.carteSurField);
                    }
                }

            }
        return lienTrouver;

    }
    public void JouerCarte(Card carte)
    {
        if (VerificationLien(true, carte))
        {
            carteSurField = carte;
            carteSurField.cardonfield = true;
            manager.playerHand.RemoveCard(carteSurField.gameObject);
            manager.selected = null;
            carteSurField.transform.position = transform.position + offset;

            foreach (GameObject child in listOfChildren)
            {
                int i = 0;
                while (i < carteSurField.direction.Length)
                {
                    if (child.name == carteSurField.direction[i].ToString())
                    {
                        MeshRenderer temp = child.GetComponent<MeshRenderer>();
                        temp.material = directionMaterial;

                    }
                    i++;
                }
            }
        }
    }

    
}
