using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiInfo : MonoBehaviour
{
    public int[] AiDeck = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public int[] aiCore = { 2, 4, 6 };
    public AiInfo mainAiInfo;
    // Start is called before the first frame update
    void Start()
    {
        if(mainAiInfo == this)
        {
            DontDestroyOnLoad(gameObject);
        }
        //jsp a quoi il sert
        //FindAnyObjectByType(typeof(AiInfo));        
    }
    // Update is called once per frame
    public void DestroyThisObject()
    {
        Destroy(gameObject);
    }

    public void PasserInfo()
    {
        mainAiInfo.AiDeck = AiDeck;
        mainAiInfo.aiCore = aiCore;
    }
}
