using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    Vector3 offset = new Vector3(0, 1, 0);
    [SerializeField] CardGameManager manager;
    internal GameObject carteSurField = null;
    bool selected = false;
    public List<GameObject> listOfChildren;
    [SerializeField] private Material directionMaterial;

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
        if (manager.selected != null)
        {

            carteSurField = manager.selected;
            Card carte = carteSurField.GetComponent<Card>();
            carte.cardonfield = true;
            carteSurField.transform.position = transform.position + offset;
            manager.selected = null;
            Debug.Log("je suis la");

            foreach (GameObject child in listOfChildren)
            {
                int i = 0;
                while(i < carte.direction.Length)
                {
                    if(child.name == carte.direction[i].ToString())
                    {
                        MeshRenderer temp = child.GetComponent<MeshRenderer>();
                        temp.material = directionMaterial;
                    }
                    i++;
                }
            }




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
