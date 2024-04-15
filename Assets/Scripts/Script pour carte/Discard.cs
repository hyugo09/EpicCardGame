using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discard : MonoBehaviour
{
    public List<GameObject> list;
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
        

    }

}
