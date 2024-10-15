using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLivesMixMayhem : MonoBehaviour
{
    public int lives = 10; // Jumlah nyawa awal

    void Update()
    {
        if (lives <= 0)
        {
            Debug.Log("Permainan Berakhir");
            // Tampilkan UI Game Over atau akhiri permainan
        }
    }

    public void LoseLife()
    {
        lives--;
        Debug.Log("Sisa nyawa: " + lives);
    }

}
