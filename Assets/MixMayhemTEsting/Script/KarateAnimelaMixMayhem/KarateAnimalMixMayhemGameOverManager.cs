using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarateAnimalMixMayhemGameOverManager : MonoBehaviour
{
    [SerializeField] private KarateAnimalMixMayhemScoreManager scoreManager;
    [SerializeField] KarateAnimalMixMayhemScoreManagerPlayer2 karatescoremanagerplayer2;
    [SerializeField] private MixMayhemPlayerLifeManager lifeManager;
    [SerializeField] private List<GameObject> miniGameObjects; // Daftar objek yang perlu dihentikan dalam mini-game (misalnya pemain, objek game)

    public void KarateAnimalTriggerEnd(string playerTag)
    {
        if (scoreManager.scorePlayer1 < karatescoremanagerplayer2.scorePlayer2)
        {
            lifeManager.DamagePlayer1();
        }
        else if (scoreManager.scorePlayer1 > karatescoremanagerplayer2.scorePlayer2)
        {
            Debug.Log("Pemain 2 kalah, nyawa berkurang!");
            lifeManager.DamagePlayer2();  // Kurangi nyawa Pemain 2 di MixMayhem
        }

        StopMiniGame();

    }
    public void StopMiniGame()
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
