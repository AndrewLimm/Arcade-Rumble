using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class catchitemMixmayhemscoremanagerplayer2 : MonoBehaviour
{

    public static catchitemMixmayhemscoremanagerplayer2 instance; // Singleton instance

    public int catchitemscorePlayer2 = 0;

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

    // Menambah skor untuk Player 2
    public void AddScore(int value)
    {
        catchitemscorePlayer2 += value;
        CatchItemMixMayhemScorePLayer2.instance.UpdateScoreUI(); // Perbarui UI setelah skor diubah
    }

    // Mengambil skor Player 2
    public int GetScore()
    {
        return catchitemscorePlayer2;
    }
}
