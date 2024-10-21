using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixMayhemPlayerLifeManager : MonoBehaviour
{
    public int player1Lives = 3;
    public int player2Lives = 3;

    // Referensi ke script LivesUIManager
    public MixMayhemUIliveManager livesUIManager;

    public void DamagePlayer1()
    {
        if (player1Lives > 0)
        {
            player1Lives--;
            livesUIManager.UpdatePlayer1Lives(player1Lives);
        }
    }

    public void DamagePlayer2()
    {
        if (player2Lives > 0)
        {
            player2Lives--;
            livesUIManager.UpdatePlayer2Lives(player2Lives);
        }
    }
}
