using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float vitesse = 5f;
    Rigidbody rb;
    private bool isMoving = false;

    void Start()
    {
        //Cacher
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        DeplaceSeulementForwardRelativeDuCameraModifier();
    }

    private void Move()
    {
        //float mouvementHorizontale = Input.GetAxis("Horizontal");
        //float mouvementDevant = Input.GetAxis("Vertical");

        Vector2 move = InputManager.mouvementInput;
        rb.velocity = new Vector3(move.x * vitesse, rb.velocity.y, move.y * vitesse);
    }
    private void DeplaceDansDirectionDuCamera()
    {
        // Trouver l'input du InputManager, je sépare les inputs pour que ce soit plus facile à comprendre
        float horizontalInput = InputManager.mouvementInput.x;
        float verticalInput = InputManager.mouvementInput.y;

        // Calculer la direction FORWARD relative à la caméra
        Vector3 forwardDirection = Camera.main.transform.forward;
        forwardDirection.y = 0; // Remove vertical movement

        // Calculer la direction RIGHT relative à la caméra
        Vector3 rightDirection = Camera.main.transform.right;

        // Combine les directions forward et right dans un seul vecteur
        Vector3 movementDirection = forwardDirection * verticalInput + rightDirection * horizontalInput;
        movementDirection.Normalize(); // Ensure the direction vector has a length of 1

        // Appliquer le mouvement au Rigidbody
        Vector3 movement = movementDirection * (vitesse * Time.deltaTime);
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
        if (movementDirection != Vector3.zero)
        {
            TurnTowardsMovementDirection(movementDirection);
        }
    }


    //Eventuellement, on utilisera cette méthode pour un meilleur feeling.
    //Le joueur ne se déplacera que vers l'avant relativement à la caméra, pas à gauche, à droite ou en arrière
    private void DeplaceSeulementForwardRelativeDuCamera()
    {
        Vector3 moveInput = new Vector3(InputManager.mouvementInput.x, 0, InputManager.mouvementInput.y);
        Vector3 moveDirection = (transform.forward * moveInput.z + transform.right * moveInput.x).normalized;
        moveDirection.y = 0;

        if (moveInput.z > 0)
        {
            if (!isMoving)
            {
                moveDirection = Camera.main.transform.forward;
                moveDirection.y = 0;

                TurnTowardsMovementDirection(moveDirection);
                isMoving = true;
            }
        }
        else
        {
            isMoving = false;
        }

        Vector3 movement = moveDirection.normalized * (vitesse * Time.fixedDeltaTime);

        rb.MovePosition(rb.position + movement);
    }



    private void DeplaceSeulementForwardRelativeDuCameraModifier()
    {
        Vector3 moveInput = new Vector3(InputManager.mouvementInput.x, 0, InputManager.mouvementInput.y);

        // Trouver l'input du InputManager, je sépare les inputs pour que ce soit plus facile à comprendre
        float horizontalInput = InputManager.mouvementInput.x;
        float verticalInput = InputManager.mouvementInput.y;

        // Calculer la direction FORWARD relative à la caméra
        Vector3 forwardDirection = Camera.main.transform.forward;
        forwardDirection.y = 0; // Remove vertical movement

        // Calculer la direction RIGHT relative à la caméra
        Vector3 rightDirection = Camera.main.transform.right;

        // Combine les directions forward et right dans un seul vecteur
        Vector3 movementDirection = forwardDirection * verticalInput + rightDirection * horizontalInput;

        //movementDirection.Normalize(); // Ensure the direction vector has a length of 1
        if (moveInput.z > 0)
        {
            //Tourner le joueur vers la direction avant de la caméra en mouvment
            movementDirection.y = 0;
            TurnTowardsMovementDirection(forwardDirection);
            isMoving = true;
        }
        else
        {
            //Tourner le joueur vers la direction avant de la caméra en arrêt
            TurnTowardsMovementDirection(forwardDirection);
            isMoving = false;
        }

        Vector3 movement = movementDirection.normalized * (vitesse * Time.fixedDeltaTime);

        rb.MovePosition(rb.position + movement);
    }

    //Cette méthode permet de tourner le joueur dans la direction du mouvement
    private void TurnTowardsMovementDirection(Vector3 moveDirection)
    {
        //Calculer la rotation à appliquer au Rigidbody
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
        rb.rotation = targetRotation;
    }

}
