using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discard : MonoBehaviour
{
    public List<GameObject> list;
    float offset = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        //jsp rn
    }

    public void SendCard(GameObject card)
    {
        float offset = 0.3f;
        list.Add(card);
        card.transform.SetParent(transform);
        ArrangeGy();

    }

    private void ArrangeGy()
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i].transform.position = new Vector3(transform.position.x, offset, transform.position.z);
        }

    }
}
