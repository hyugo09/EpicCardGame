using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapArrow : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    [SerializeField] private Transform player;


    void Update()
    {
        Vector3 arrowRotation = arrow.transform.eulerAngles;
        arrowRotation.z = -player.eulerAngles.y + 180;
        arrow.transform.eulerAngles = arrowRotation;
    }
}
