using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCardCollected : MonoBehaviour
{
    [SerializeField] internal List<CardMenu> Collection;
    public bool changer = false;
    public void AddToCollection(CardMenu carte)
    {
        Collection.Add(carte);
        changer = true;
    }

}
