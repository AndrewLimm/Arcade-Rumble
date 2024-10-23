using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionTestMixMayhemGameOverManager : MonoBehaviour
{
    [SerializeField] ReactionTestMixMayhemScoreManager reactiontestScoreManager;
    [SerializeField] MixMayhemPlayerLifeManager mixMayhemPlayerLifeManager;
    [SerializeField] private List<GameObject> miniGameObjects; // Daftar objek yang perlu dihentikan dalam mini-game (misalnya pemain, objek game)\

    public void ReactionTestEndTrigger(string playerTag)
    {
        if (reactiontestScoreManager.reactiontestplayer1Score < reactiontestScoreManager.reactiontestplayer2Score)
        {
            mixMayhemPlayerLifeManager.DamagePlayer1();
        }
        else if (reactiontestScoreManager.reactiontestplayer1Score > reactiontestScoreManager.reactiontestplayer2Score)
        {
            mixMayhemPlayerLifeManager.DamagePlayer2();
        }

        stopMinigames();
    }
    public void stopMinigames()
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
