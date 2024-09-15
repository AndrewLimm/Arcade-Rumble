using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverManagerTextReactionGame : MonoBehaviour
{
    public GameObject gameOverPanel;  // Panel UI untuk Game Over
    public TMP_Text gameOverText;  // Text UI untuk hasil akhir

    void OnEnable()
    {
        ReactionMechanic.GameEndEvent += OnGameEnd;  // Daftarkan event untuk menerima hasil akhir
    }

    void OnDisable()
    {
        ReactionMechanic.GameEndEvent -= OnGameEnd;  // Hapus pendaftaran event
    }

    void OnGameEnd(string result)
    {
        gameOverPanel.SetActive(true);  // Tampilkan panel Game Over
        gameOverText.text = result;  // Tampilkan hasil akhir
    }
}
