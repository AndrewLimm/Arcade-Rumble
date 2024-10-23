using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixMayhemPlayerLifeManager : MonoBehaviour
{
    public int player1Lives = 2;
    public int player2Lives = 2;

    // Referensi ke script LivesUIManager
    public MixMayhemUIliveManager livesUIManager;

    public void DamagePlayer1()
    {
        if (player1Lives > 0)
        {
            player1Lives--;
            livesUIManager.UpdatePlayer1Lives(player1Lives);
            CheckGameOver();

        }
    }

    public void DamagePlayer2()
    {
        if (player2Lives > 0)
        {
            player2Lives--;
            livesUIManager.UpdatePlayer2Lives(player2Lives);
            CheckGameOver();

        }
    }

    private void CheckGameOver()
    {
        // Memanggil fungsi di GameOverManager untuk mengecek apakah permainan berakhir
        if (player1Lives == 0 || player2Lives == 0)
        {
            FindObjectOfType<MixmAyhemGameOverManager>().EndGameMixMayhem();
        }
    }
}
