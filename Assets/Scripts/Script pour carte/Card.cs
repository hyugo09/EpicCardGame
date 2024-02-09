using Palmmedia.ReportGenerator.Core.Reporting.History;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    private bool selected;

    public GameObject Player;
    [SerializeField] private int attack;
    [SerializeField] private int defense;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!selected)
        {
            
        }

        if (Input.GetMouseButtonDown(0))
        {
            selected = false;
        }


    }
    private void OnMouseDrag()
    {
        Debug.Log("mouse dragging");
        selected = true;
        Vector3 MousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        Quaternion toRotation = Quaternion.Euler((MousePosition.x - transform.position.x) * 90, -(MousePosition.y - transform.position.z) * 90, 0);
        MousePosition.z = MousePosition.y;
        MousePosition.y = transform.position.y;
        transform.position = Vector3.Lerp(transform.position, MousePosition, Time.deltaTime * 15f);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Time.deltaTime);

    }
}
