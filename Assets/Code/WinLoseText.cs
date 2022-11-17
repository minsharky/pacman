using System;
using UnityEngine;
using UnityEngine.UI;

public class WinLoseText : MonoBehaviour
{
    public static Text winLoseText;
    internal void Start()
    {
        winLoseText = GetComponent<Text>();
    }

    public static void UpdateWinLoseText(bool win)
    {
        if (win)
        {
            winLoseText.text = "You Win!";
        }
        else
        {
            winLoseText.text = "You Lose";
        }
    }

}
