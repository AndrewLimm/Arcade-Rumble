using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixMayhemPlayerlifeManagerTestign : MonoBehaviour
{
    public MixMayhemPlayerLifeManager playerLifeManager; // Referensi ke PlayerLifeManager

    // Menambahkan menu konteks untuk mengurangi nyawa Player 1
    [ContextMenu("Damage Player 1")]
    public void DamagePlayer1()
    {
        if (playerLifeManager != null)
        {
            playerLifeManager.DamagePlayer1(); // Memanggil metode untuk mengurangi nyawa Player 1
        }
        else
        {
            Debug.LogWarning("PlayerLifeManager tidak diatur!");
        }
    }

    // Menambahkan menu konteks untuk mengurangi nyawa Player 2
    [ContextMenu("Damage Player 2")]
    public void DamagePlayer2()
    {
        if (playerLifeManager != null)
        {
            playerLifeManager.DamagePlayer2(); // Memanggil metode untuk mengurangi nyawa Player 2
        }
        else
        {
            Debug.LogWarning("PlayerLifeManager tidak diatur!");
        }
    }
}
