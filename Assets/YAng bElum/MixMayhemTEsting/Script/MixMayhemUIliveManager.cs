using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MixMayhemUIliveManager : MonoBehaviour
{
    public Image[] player1Hearts; // Image hati untuk Player 1
    public Image[] player2Hearts; // Image hati untuk Player 2

    // Memperbarui tampilan nyawa Player 1
    public void UpdatePlayer1Lives(int lives)
    {
        Debug.Log("Memperbarui Nyawa Player 1: " + lives);
        for (int i = 0; i < player1Hearts.Length; i++)
        {
            // Mengatur visibilitas hati berdasarkan jumlah nyawa
            player1Hearts[i].gameObject.SetActive(i < lives); // Aktif jika masih ada nyawa
        }
    }

    // Memperbarui tampilan nyawa Player 2
    public void UpdatePlayer2Lives(int lives)
    {
        Debug.Log("Memperbarui Nyawa Player 2: " + lives);
        for (int i = 0; i < player2Hearts.Length; i++)
        {
            // Mengatur visibilitas hati berdasarkan jumlah nyawa
            player2Hearts[i].gameObject.SetActive(i < lives); // Aktif jika masih ada nyawa
        }
    }
}
