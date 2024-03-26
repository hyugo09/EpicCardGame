using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArreterCamera : MonoBehaviour
{
    GameManager gameManager;
    GameObject camera;
    private void Start()
    {
        camera = this.gameObject;
    }
    private void Update()
    {
        if (Time.timeScale == 0)
        {
            camera.transform.rotation = new Quaternion(0,0,0,0);
        }
        else { }
    }


}
