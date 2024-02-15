using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    Vector3 offset = new Vector3(0, 1, 0);
    [SerializeField] CardPlayer player;
    internal GameObject carteSurField = null;
    bool slected = false;
    public List<GameObject> listOfChildren;
    private Renderer[] childrenderer;

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
        if (player.selected != null)
        {

            carteSurField = player.selected;
            Card carte = carteSurField.GetComponent<Card>();
            carte.cardonfield = true;
            player.selected = null;
               Debug.Log("je suis la");
               for (int i =0; i >= carte.fleche.Length; i++)
               {
                 foreach (GameObject child in listOfChildren)
                {
                    if (child.name == carte.fleche[i].ToString())
                    {
                        MeshRenderer temp = child.GetComponent<MeshRenderer>();
                        
                    }
                }
               }
          
            carteSurField.transform.position = transform.position + offset;

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
}
