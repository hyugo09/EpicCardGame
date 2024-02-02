using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SuivreCible : MonoBehaviour
{
    [SerializeField] private Transform cible;
    
    private Vector3 offset;
    
    private void Awake()
    {
        offset = transform.position - cible.position;
    }
    
    private void LateUpdate()
    {
        transform.position = cible.position + offset;
    }
}
