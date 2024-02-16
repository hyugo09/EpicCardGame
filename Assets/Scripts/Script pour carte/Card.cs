using Palmmedia.ReportGenerator.Core.Reporting.History;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Card : MonoBehaviour
{

    internal bool selected;

    public CardGameManager manager;
    [SerializeField] private int attack;
    [SerializeField] private int defense;
    public bool cardonfield = false;
    public int[] direction = {3};

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

    private void OnMouseDown()
    {
        if (cardonfield == false)
        {
            Debug.Log("selectionner");
            if (manager.selected != null)
            {
                manager.selected.GetComponent<Card>().selected = false;
                manager.selected.transform.position = manager.originalposSelected;
            }

            manager.selected = this.gameObject;
            manager.originalposSelected = this.gameObject.transform.position;
            transform.position = new Vector3(transform.position.x + 5, transform.position.y + 10, transform.position.z);
            selected = true;
        }
    }

    //private void OnMouseDrag()
    //{
    //    Debug.Log("mouse dragging");
    //    selected = true;
    //    Vector3 MousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
    //    Quaternion toRotation = Quaternion.Euler((MousePosition.x - transform.position.x) * 90, -(MousePosition.y - transform.position.z) * 90, 0);
    //    MousePosition.z = MousePosition.y;
    //    MousePosition.y = transform.position.y;
    //    transform.position = Vector3.Lerp(transform.position, MousePosition, Time.deltaTime * 15f);
    //    transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Time.deltaTime);

    //}
}
