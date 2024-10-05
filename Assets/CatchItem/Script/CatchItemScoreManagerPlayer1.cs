using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchItemScoreManagerPlayer1 : MonoBehaviour
{
    public static CatchItemScoreManagerPlayer1 instance; // Singleton instance

    private int scorePlayer1 = 0;

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
        scorePlayer1 += value;
        CatchItemScoreUIPlayer1.instance.UpdateScoreUI(); // Perbarui UI setelah skor diubah
    }

    // Mengambil skor Player 1
    public int GetScore()
    {
        return scorePlayer1;
    }
}
