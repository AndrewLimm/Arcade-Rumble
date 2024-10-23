using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchITemMixMayhemGameOver : MonoBehaviour
{
    [SerializeField] catchitemMixmayhemscoremanagerplayer2 catchitemMixmayhemscoremanagerplayer2;
    [SerializeField] CtachItemMixmayhemScoreManagerplayer1 ctachItemMixmayhemScoreManagerplayer1;
    [SerializeField] MixMayhemPlayerLifeManager mixMayhemPlayerLifeManager;
    [SerializeField] private List<GameObject> miniGameObjects; // Daftar objek yang perlu dihentikan dalam mini-game (misalnya pemain, objek game)


    public void CatchItemTriggerEnd(string playerTag)
    {
        if (ctachItemMixmayhemScoreManagerplayer1.catchitemscorePlayer1 < catchitemMixmayhemscoremanagerplayer2.catchitemscorePlayer2)
        {
            mixMayhemPlayerLifeManager.DamagePlayer1();
        }
        else if (ctachItemMixmayhemScoreManagerplayer1.catchitemscorePlayer1 > catchitemMixmayhemscoremanagerplayer2.catchitemscorePlayer2)
        {
            mixMayhemPlayerLifeManager.DamagePlayer2();
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
