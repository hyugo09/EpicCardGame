using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Rendering;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cameraNormale;
    [SerializeField] private CinemachineVirtualCamera cameraViser;
    [SerializeField] private Camera mainCamera;



    void FixedUpdate()
    {
        mainCamera.depthTextureMode = DepthTextureMode.DepthNormals;
        //if (InputManager.isAimingInput == true)
        //{
        //    cameraNormale.Priority = 1;
        //    cameraViser.Priority = 0;
        //}
        //else if (InputManager.isAimingInput == false)
        //{
        //    cameraNormale.Priority = 0;
        //    cameraViser.Priority = 1;
        //}
    }

}
