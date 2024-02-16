using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lien : MonoBehaviour
{
    [SerializeField] internal Field field1;
    [SerializeField] internal Field field2;

    private TextMeshPro text;

    private int PV;
    private int currentPV = 0;
    private void Awake()
    {
        text = GetComponent<TextMeshPro>();
        setLienPV();
    }

    public void setLienPV()
    {
        if(field1.carteSurField != null & field2.carteSurField)
        {
            if (currentPV != 0 || currentPV != PV)
            {
                int temp = PV;
                PV = field1.carteSurField.defense + field2.carteSurField.defense;
                currentPV += PV - temp;
            }
            else
            {
                PV = field1.carteSurField.defense + field2.carteSurField.defense;
                currentPV = PV;
            }  
        }
        SetLienText();
    }

    public void SetLienText()
    {
        text.text = currentPV.ToString();
    }
}
