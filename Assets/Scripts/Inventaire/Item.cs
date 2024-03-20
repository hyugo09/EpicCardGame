using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new item", menuName = "Inventaire/Créer un nouveau item", order = 0)]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public bool isStackable = true;
}




