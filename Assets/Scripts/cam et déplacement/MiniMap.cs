using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;
    [SerializeField] private Transform cameraPosition;
   

    private void Update()
    {
        cameraPosition.transform.position = playerPosition.position;
        
    }


}
