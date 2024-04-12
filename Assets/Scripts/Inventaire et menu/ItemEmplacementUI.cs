using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemEmplacementUI : MonoBehaviour
{
    public Item monItem;
    public Image image;
    public TMP_Text text;

    public void UpdateUI(Item item)
    {
        monItem = item;
        image.sprite = item.itemIcon;

        if(item.isStackable)
        {
            //text.text = 
        }
        else
        {
            text.text = "";
        }

    }
}
