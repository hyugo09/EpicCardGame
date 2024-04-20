using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutoPages : MonoBehaviour
{
    public GameObject[] pages;
    public int index = 0;
    public TextMeshProUGUI text;
    
    public void PageSuivante()
    {
        if (index < pages.Length)
        {
            pages[index].SetActive(false);
            index++;
            pages[index].SetActive(true);
            text.text = (index + 1).ToString();
        }
        
    }
    public void PagePrecedante()
    {
        pages[index].SetActive(false);
        index--;
        pages[index].SetActive(true);
        text.text = (index + 1).ToString();
    }
}
