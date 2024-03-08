using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BattleStartCameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera firstCamera;
    [SerializeField] private CinemachineVirtualCamera battleCamera;
    [SerializeField] private CinemachineVirtualCamera EnnemieCamera;
    [SerializeField] private GameObject button;
    
    void Start()
    {
        firstCamera.Priority = 1;
        battleCamera.Priority = 0;
        EnnemieCamera.Priority = 0;
        button.SetActive(false);
        StartCoroutine(changementCamera(0.01f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator changementCamera(float delais)
    {
        yield return new WaitForSeconds(delais);
        firstCamera.Priority = 0;
        battleCamera.Priority = 1;
        StartCoroutine(ActivateUI(3.8f));
        
    }
    public IEnumerator ActivateUI(float delais)
    {
        yield return new WaitForSeconds (delais);
        button.SetActive (true);
        
    }
    public void SwitchCam()
    {
        if(battleCamera.Priority == 1)
        {
            battleCamera.Priority = 0;
            EnnemieCamera.Priority =1;
        }
        else
        {
            battleCamera.Priority = 1;
            EnnemieCamera.Priority = 0; 
        }
    }
}
