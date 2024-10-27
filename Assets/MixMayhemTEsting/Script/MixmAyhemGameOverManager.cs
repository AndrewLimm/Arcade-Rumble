using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MixmAyhemGameOverManager : MonoBehaviour
{
    [SerializeField] MixMayhemPlayerLifeManager mixMayhemPlayerlifeManager;
    public void EndGameMixMayhem()
    {
        // Memeriksa jumlah nyawa pemain
        if (mixMayhemPlayerlifeManager.player1Lives < mixMayhemPlayerlifeManager.player2Lives)
        {
            // Pemain 2 menang
            Debug.Log("Pemain 2 menang!");
            GameRumbleGameManagerForScore.instance.AddWinPoint(2);
            Invoke("GoToResultScreen", 0.5f); // Menunggu 2 detik sebelum pindah

        }
        else if (mixMayhemPlayerlifeManager.player1Lives > mixMayhemPlayerlifeManager.player2Lives)
        {
            // Pemain 1 menang
            Debug.Log("Pemain 1 menang!");
            GameRumbleGameManagerForScore.instance.AddWinPoint(1);
            Invoke("GoToResultScreen", 0.5f); // Menunggu 2 detik sebelum pindah

        }
    }

    private void GoToResultScreen()
    {
        SceneManager.LoadScene("ArcadeRumbleResultScreen"); // Ganti dengan nama scene layar hasil yang sesuai
    }
}

