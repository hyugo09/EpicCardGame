using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce = 3f;
    Rigidbody rb;

    public bool isGrounded = false;

    public float groundCheckDistance;
    private float bufferCheckDistance = 0.1f;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        jump();

    }

    private void jump()
    {
        groundCheckDistance = (GetComponent<CapsuleCollider>().height / 2) + bufferCheckDistance;

        if (InputManager.jumpInput == true && isGrounded)
        {
            //rb.AddForce(transform.up * 3, ForceMode.Impulse);
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            if (rb.velocity.y == 0)
            {
                rb.AddForce(Vector3.zero, 0f);
            }
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, groundCheckDistance))
        {
            isGrounded = true;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

        }
        else
        {
            isGrounded = false;
        }

    }


}
