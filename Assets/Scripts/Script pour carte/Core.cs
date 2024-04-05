using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Card))]
[RequireComponent(typeof(Lien))]
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
        Carte.manager.selected = this.gameObject;
    }

    
}
