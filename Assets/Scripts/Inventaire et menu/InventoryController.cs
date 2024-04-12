using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{

    public Dictionary<Item,int> items = new Dictionary<Item,int>();

    public static object OnInventaireModifier { get; internal set; }

    public void AddItem(Item item, int amount = 1)
    {
        if (items.TryAdd(item,amount))// TryAdd, retourne vrai ou faux
        {
            items[item] += amount;
        }
    }

    public void RemoveItem(Item item, int amount = 1)
    {

    }
}
