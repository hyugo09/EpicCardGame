using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoreMenu : MonoBehaviour
{
    [SerializeField] internal PlayerInfo playerInfo;
    [SerializeField] private TextMeshProUGUI textPV;
    private void Awake()
    {
        textPV.text = playerInfo.corePV.ToString();
    }
    public void AddCoreDirection(int direction)
    {
        if (playerInfo.coreDirections.Contains(direction))
        {
            RemoveCoreDirection(direction);
            return;
        }
        if (playerInfo.corePV - 10 > 0)
        {
            playerInfo.corePV -= 10;
            playerInfo.coreDirections.Add(direction);
            textPV.text = playerInfo.corePV.ToString();
        }
    }
    public void ChangeColor(Image image)
    {
        if (playerInfo.corePV - 10 > 0 && image.color == Color.white)
        {
            image.color = Color.blue;
        }
        else
        {
            image.color = Color.white;
        }
    }
    private void RemoveCoreDirection(int direction)
    {
        playerInfo.corePV += 10;
        playerInfo.coreDirections.Remove(direction);
        textPV.text = playerInfo.corePV.ToString();
    }
}
