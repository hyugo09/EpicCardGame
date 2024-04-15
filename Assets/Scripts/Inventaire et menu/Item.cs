using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "new item", menuName = "Inventaire/Créer un nouveau item", order = 0)]
public class Item : ScriptableObject
{
    public GameObject cardModel;
    public string itemName;
    public Sprite itemIcon;
    public Material itemMaterial;
    public bool isStackable = true;
   
}




