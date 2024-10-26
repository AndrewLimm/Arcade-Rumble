using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIxMayhemRaceTofinishGameOverManager : MonoBehaviour
{
    [SerializeField] private MixMayhemPlayerLifeManager playerLifeManager;
    [SerializeField] private Transform finishLine;  // Referensi ke garis finish
    private bool gameEnded = false; // Menyimpan status apakah permainan telah berakhir
    [SerializeField] private List<GameObject> miniGameObjects; // Daftar objek yang perlu dihentikan dalam mini-game (misalnya pemain, objek game)\


    public void RaceToFinishGameOver(string playerTag)
    {
        if (gameEnded) return; // Mencegah pemanggilan berulang jika permainan sudah selesai
        gameEnded = true;  // Menandakan bahwa permainan telah selesai

        // Cek pemain mana yang mencapai garis finish dan berikan damage ke pemain yang sesuai
        if (playerTag == "Player 1")
        {
            playerLifeManager.DamagePlayer2();  // Berikan damage ke Player 1
        }
        else if (playerTag == "Player 2")
        {
            playerLifeManager.DamagePlayer1();  // Berikan damage ke Player 2
        }

        StopMiniGames();  // Hentikan semua mini-game terkait
    }

    private void StopMiniGames()
    {
        // Nonaktifkan objek atau script terkait mini-game
        foreach (GameObject obj in miniGameObjects)
        {
            obj.SetActive(false); // Nonaktifkan setiap objek yang terlibat dalam mini-game
        }
    }

}
