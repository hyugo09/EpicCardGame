using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Field : MonoBehaviour
{
    Vector3 offset = new Vector3(0, 1, 0);
    public CardGameManager manager;
    [SerializeField]internal Card carteSurField = null;
    
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
        if (manager.selected != null && manager.selected.GetComponent<Card>() != null)
        {
            carteSurField = manager.selected.GetComponent<Card>(); ;
            carteSurField.cardonfield = true;
            manager.playerHand.RemoveCard(carteSurField.gameObject);
            carteSurField.transform.position = transform.position + offset;
            manager.selected = null;

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

    private void VerificationLien(bool repeat)
    {
        bool lienTrouver = false;
        if (carteSurField != null)
            foreach (Lien lien in liens)
            {
                for (int i = 0; i < carteSurField.direction.Length; i++)
                {
                    if (position != 2 || position != 5 || position != 8)
                    {
                        

                            if (lien.gameObject.name == $"{position}-{carteSurField.direction[i]}")
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
                                                    if (carteSurField.direction[i] == 9)
                                                    {
                                                        lienTrouver = true;
                                                        lien.gameObject.SetActive(true);
                                                        lien.setLienPV();
                                                    }
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    if (carteSurField.direction[i] == 8)
                                                    {
                                                        lienTrouver = true;
                                                        lien.gameObject.SetActive(true);
                                                        lien.setLienPV();
                                                    }
                                                    break;
                                                }
                                            case 3:
                                                {
                                                    if (carteSurField.direction[i] == 7)
                                                    {
                                                        lienTrouver = true;
                                                        lien.gameObject.SetActive(true);
                                                        lien.setLienPV();
                                                    }
                                                    break;
                                                }
                                            case 4:
                                                {
                                                    if (carteSurField.direction[i] == 6)
                                                    {
                                                        lienTrouver = true;
                                                        //lien.gameObject.SetActive(true);
                                                        lien.setLienPV();
                                                    }
                                                    break;
                                                }
                                            case 6:
                                                {
                                                    if (carteSurField.direction[i] == 4)
                                                    {
                                                        lienTrouver = true;
                                                        //lien.gameObject.SetActive(true);
                                                        lien.setLienPV();
                                                    }
                                                    break;
                                                }
                                            case 7:
                                                {
                                                    if (carteSurField.direction[i] == 3)
                                                    {
                                                        lienTrouver = true;
                                                        lien.gameObject.SetActive(true);
                                                        lien.setLienPV();
                                                    }
                                                    break;
                                                }
                                            case 8:
                                                {
                                                    if (carteSurField.direction[i] == 2)
                                                    {
                                                        lienTrouver = true;
                                                        lien.gameObject.SetActive(true);
                                                        lien.setLienPV();
                                                    }
                                                    break;
                                                }
                                            case 9:
                                                {
                                                    if (carteSurField.direction[i] == 1)
                                                    {
                                                        lienTrouver = true;
                                                        lien.gameObject.SetActive(true);
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
                            // apres if (lien.gameObject.name == $"{position}-{carteSurField.direction[i]}") 
                       
                    }
                    else if (carteSurField.direction[i] == 2 || carteSurField.direction[i] == 8)
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
                        break;
                    }

                    if (field != null)
                    {
                        field.VerificationLien(false);
                    }
                }



            }


    }
    public void JouerCarte(GameObject go)
    {
        carteSurField = go.GetComponent<Card>(); ;
        carteSurField.cardonfield = true;
        manager.playerHand.RemoveCard(carteSurField.gameObject);
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
