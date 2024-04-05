using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    internal Card Carte;
    internal Lien Lien;
    internal Field Field;
    // Start is called before the first frame update
    void Start()
    {
        Carte = GetComponent<Card>();
        Lien = GetComponent<Lien>();

    }

    
}
