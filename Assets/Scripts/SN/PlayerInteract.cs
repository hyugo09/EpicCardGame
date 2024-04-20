using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Camera cam;
    public bool inRange = false;
    public GameObject dialogueUI;
    public Transform playerTransform;
    
    private void Update()
    {
        Ray raycast = cam.ScreenPointToRay(transform.position);

        RaycastHit raycastHit;

        bool weHitSomething = Physics.Raycast(raycast, out raycastHit);

        Vector3 rayOrigin = cam.transform.position;
        Vector3 rayDirection = cam.transform.forward;

        weHitSomething = Physics.Raycast(rayOrigin, rayDirection, out raycastHit, 5f);

        //Ray anotherRay = new Ray(rayOrigin, 10f * rayDirection);

        Debug.DrawRay(rayOrigin, 5f * rayDirection, Color.blue);

        if (weHitSomething && raycastHit.collider.CompareTag("NPC") && !dialogueUI.activeSelf)
        {
            //Debug.Log("TOUCHEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
            inRange = true;
        }
        else
        {
            inRange = false;
        }
        
    }
}
