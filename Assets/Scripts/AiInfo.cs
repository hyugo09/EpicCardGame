using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiInfo : MonoBehaviour
{
    public int[] AiDeck = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public int[] aiCore = { 2, 4, 6 };
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        FindAnyObjectByType(typeof(AiInfo));

    }

    // Update is called once per frame
    void Update()
    {

    }
}
