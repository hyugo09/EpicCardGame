using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[CreateAssetMenu]
public class CardMenu : MonoBehaviour
{   //j'ai essaye de le faire en scriptable object mais sa voulait pas marcher
    public int ID;
    public Sprite Image;
    
    public void ChangeValue(int newID, Sprite newImage)
    {
        ID = newID;
        Image = newImage;
    }
}
