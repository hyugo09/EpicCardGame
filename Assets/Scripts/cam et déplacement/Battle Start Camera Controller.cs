using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BattleStartCameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera firstCamera;
    [SerializeField] private CinemachineVirtualCamera battleCamera;
    void Start()
    {
        firstCamera.Priority = 1;
        battleCamera.Priority = 0;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(changementCamera(0.01f));
    }
    IEnumerator changementCamera(float delais)
    {
        yield return new WaitForSeconds(delais);
        firstCamera.Priority = 0;
        battleCamera.Priority = 1;
    }
}
