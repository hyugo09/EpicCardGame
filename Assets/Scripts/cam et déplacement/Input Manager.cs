using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    Rigidbody rb;
    PlayerControls controls;

    public static Vector2 mouvementInput;
    public static Vector2 tournerInput;

    public static bool jumpInput = false;
    public static bool isAimingInput = false;



    private void Awake()
    {
        controls = new PlayerControls();
        controls.Player.Enable();
    }

    private void OnEnable()
    {
        //controls.Player.Mouvement.started += Move;
        controls.Player.Mouvement.performed += Move;
        controls.Player.Mouvement.canceled += Move;

        //controls.Player.Tourner.started += Tourner;
        controls.Player.Tourner.performed += Tourner;
        controls.Player.Tourner.canceled += Tourner;

        controls.Player.Viser.performed += ctx => isAimingInput = true;
        controls.Player.Viser.canceled += ctx => isAimingInput = false;

        controls.Player.Saut.performed += ctx => jumpInput = true;
        controls.Player.Saut.canceled += ctx => jumpInput = false;


    }
    private void FixedUpdate()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.yellow);
            Debug.Log("Did not Hit");
        }
    }

    private void OnDisable()
    {
        //controls.Player.Mouvement.Disable();
        controls.Player.Mouvement.performed -= Move;
        controls.Player.Tourner.performed -= Tourner;

    }

    private void Move(InputAction.CallbackContext ctx) //ctx:  contexte
    {
        //Vector2 mouvement = ctx.ReadValue<Vector2>();
        mouvementInput = ctx.ReadValue<Vector2>();

        Debug.Log(mouvementInput);
    }

    private void Tourner(InputAction.CallbackContext ctx)
    {
        tournerInput = ctx.ReadValue<Vector2>();
    }

    //public void OnJump(InputAction.CallbackContext ctx)
    //{

    //    jumpInput = ctx.ReadValue<bool>();

    //}
}
