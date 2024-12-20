using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayAliveMixMayhemGameOverManager : MonoBehaviour
{
    [SerializeField] private MixMayhemPlayerLifeManager lifeManager;
    [SerializeField] private List<GameObject> miniGameObjects; // Daftar objek yang perlu dihentikan dalam mini-game (misalnya pemain, objek game)

    public void TriggerEnd(string playerTag)
    {
        // Logika untuk memicu game over di mini-game
        Debug.Log("Game Over di Mini-Game! Pemain telah kalah.");

        // Kurangi nyawa di Mix Mayhem sesuai dengan pemain yang kalah
        if (playerTag == "Player1")
        {
            lifeManager.DamagePlayer1();
        }
        else if (playerTag == "Player2")
        {
            lifeManager.DamagePlayer2();
        }

        // Hentikan logika mini-game tanpa menghentikan seluruh permainan
        StopMiniGame();
    }

    private void StopMiniGame()
    {
        // Hentikan objek-objek terkait mini-game, misalnya pemain, musuh, atau mekanisme mini-game lainnya
        foreach (GameObject obj in miniGameObjects)
        {
            obj.SetActive(false); // Nonaktifkan setiap objek yang terlibat dalam mini-game
        }

        // Jika ingin, Anda juga bisa menonaktifkan script tertentu pada objek pemain, contoh:
        // GetComponent<Player1Controller>().enabled = false;
    }
}
