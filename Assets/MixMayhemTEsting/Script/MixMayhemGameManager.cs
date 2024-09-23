using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixMayhemGameManager : MonoBehaviour
{
    public GameObject[] miniGamePanels; // Daftar panel untuk menampung mini-games

    void Start()
    {
        StartRandomMiniGames(0); // Mulai permainan dengan panel 0 sebagai contoh
    }

    void StartRandomMiniGames(int panelIndex)
    {
        if (panelIndex < 0 || panelIndex >= miniGamePanels.Length)
        {
            Debug.LogError("Panel index tidak valid!");
            return;
        }

        GameObject panel = miniGamePanels[panelIndex];

        // Nonaktifkan semua mini-games dalam panel
        foreach (Transform child in panel.transform)
        {
            child.gameObject.SetActive(false); // Menonaktifkan semua mini-game
        }

        // Aktifkan satu mini-game secara acak dari panel
        int randomIndex = Random.Range(0, panel.transform.childCount);
        panel.transform.GetChild(randomIndex).gameObject.SetActive(true); // Aktifkan salah satu mini-game
    }

    public void EndMiniGame(GameObject miniGame, int panelIndex)
    {
        miniGame.SetActive(false); // Menonaktifkan mini-game yang berakhir
        StartRandomMiniGames(panelIndex); // Mulai mini-game baru di panel yang sama
    }
}
