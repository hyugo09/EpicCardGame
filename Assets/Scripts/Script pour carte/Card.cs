
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Card : MonoBehaviour
{

    internal bool selected;
    public bool canAttack;
    public CardGameManager manager;
    [SerializeField] internal int attack;
    [SerializeField] internal int defense;
    public bool cardonfield = false;
    public int[] direction = {3};
    public float width;

    // Start is called before the first frame update
    void Start()
    {
        //?????????????? pk
        width = this.width* this.transform.localScale.x;

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
                if(manager.selected.GetComponent<Card>() != null)
                {
                    manager.selected.GetComponent<Card>().selected = false;
                    manager.selected.transform.position = manager.originalposSelected;
                }
                else
                {
                    //je sais pas encore donc r pour le moment
                    //je vais devoir bouger ce code a manager anyway pour que cette partie marche
                }
            }
            else if(manager.currentPhase == CardGameManager.Phase.main)
            {
                transform.position = new Vector3(transform.position.x + 5, transform.position.y + 10, transform.position.z);
            }
            manager.selected = this.gameObject;
            manager.originalposSelected = this.gameObject.transform.position;
            selected = true;
        }
        else if (manager.currentPhase == CardGameManager.Phase.battle)
        {
            manager.selected = this.gameObject;
            manager.originalposSelected = this.gameObject.transform.position;
            selected = true;
            BattleStartCameraController b = GameObject.FindFirstObjectByType<BattleStartCameraController>().GetComponent<BattleStartCameraController>();
            b.SwitchCam();
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
