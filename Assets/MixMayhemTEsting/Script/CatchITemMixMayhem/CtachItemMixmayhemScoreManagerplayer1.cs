using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtachItemMixmayhemScoreManagerplayer1 : MonoBehaviour
{
    public static CtachItemMixmayhemScoreManagerplayer1 instance; // Singleton instance

    public int catchitemscorePlayer1 = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Agar tetap ada di setiap scene
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Menambah skor untuk Player 1
    public void AddScore(int value)
    {
        catchitemscorePlayer1 += value;
        CatchItemMixMayhemScoreUiPlayer.instance.UpdateScoreUI(); // Perbarui UI setelah skor diubah
    }

    // Mengambil skor Player 1
    public int GetScore()
    {
        return catchitemscorePlayer1;
    }
}
