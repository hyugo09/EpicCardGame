using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    Rigidbody rb;
    PlayerControls controls;
    GameManager gameManager;

    public static Vector2 mouvementInput;
    public static Vector2 tournerInput;

    public static bool jumpInput = false;
    public static bool isAimingInput = false;

    public static bool isInteracting = false;
    public static bool escapeInput = false;
    public static bool leftClickInput = false;



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

        //interaction NPC
        controls.Player.InteractionNPC.started += ctx => isInteracting = true;
        //controls.Player.InteractionNPC.performed += ctx => isInteracting = true;
        controls.Player.InteractionNPC.canceled += ctx => isInteracting = false;

        //Escape (Menu)
        controls.Player.Escape.started += ctx => escapeInput = true;
        controls.Player.Escape.canceled += ctx => escapeInput = false;

        //Clique gauche(carte)
        controls.JeuCartes.CliqueGauche.performed += ctx => leftClickInput = true;
        controls.JeuCartes.CliqueGauche.canceled += ctx => leftClickInput = false;

        //if (controls.Player.Escape.phase == InputActionPhase.Started && !gameManager.isPaused)
        //{
        //    controls.Player.Escape.canceled += ctx => escapeInput = true;
        //}
        //else
        //{
        //    controls.Player.Escape.canceled += ctx => escapeInput = false;
        //}



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
