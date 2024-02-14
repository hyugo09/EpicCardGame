using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tourner : MonoBehaviour
{
    public Transform player;
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private float yClamp = 60;


    private float xRotation = 0;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        //RotateCamera();
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;


        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);

    }
}
