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
    [SerializeField] private float jumpHeight = 5f;
    Rigidbody rb;

    private bool isGrounded = false;

    private float groundCheckDistance;
    private float bufferCheckDistance = 0.1f;

    private bool canJump = true;
    private float jumpCooldown = 0.1f;

    public float gravityScale = 1f;
    public float fallingGravityScale = 40f;


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

        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, groundCheckDistance))
        {

            isGrounded = true;
        }

        if (canJump == true)
        {

            if (InputManager.jumpInput == true && isGrounded)
            {

                //https://gamedevbeginner.com/how-to-jump-in-unity-with-or-without-physics/

                float jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics.gravity.y * gravityScale));
                //rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);

                rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
                
                isGrounded = false;



            }
            else if (InputManager.jumpInput == true && !isGrounded)
            {
                StartCoroutine(jumpCooldownFunction(jumpCooldown));
            }


        }

    }

    IEnumerator jumpCooldownFunction(float time)
    {
        canJump = false;
        //Debug.Log("no do");
        yield return new WaitForSeconds(time);
        canJump = true;
        //Debug.Log("Yes do");
    }
}
