
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
    public int[] direction = { 3 };
    public float width;

    // Start is called before the first frame update
    void Start()
    {
        width = this.width * this.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (!selected)
        {

        }

        if (InputManager.leftClickInput)
        {
            selected = false;
        }


    }

    private void OnMouseDown()
    {

        if (cardonfield == false && (manager.selected == null || !manager.selected.GetComponent<Core>()))
        {
            Debug.Log("selectionner");
            if (manager.selected != null)
            {
                if (manager.selected.GetComponent<Card>() != null)
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
            if (manager.currentPhase == CardGameManager.Phase.battle)
            {
                BattleStartCameraController b = GameObject.FindFirstObjectByType<BattleStartCameraController>();
                b.SwitchCam();
            }

            manager.selected = this.gameObject;
            manager.originalposSelected = this.gameObject.transform.position;
            transform.position = new Vector3(transform.position.x, transform.position.y + 8, transform.position.z + 3); //Détermine la position de la carte après l'avoir pris
            selected = true;
        }
        else if (manager.currentPhase == CardGameManager.Phase.battle && !GetComponent<Core>())
        {
            manager.selected = this.gameObject;
            manager.originalposSelected = this.gameObject.transform.position;
            selected = true;
            BattleStartCameraController b = GameObject.FindFirstObjectByType<BattleStartCameraController>().GetComponent<BattleStartCameraController>();
            b.SwitchCam();
        }

    }

    internal void EnvoyerAuCimetiere()
    {
        cardonfield = false;
        manager.playerDiscard.list.Add(this.gameObject);
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
