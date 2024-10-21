using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixMayhemGameManager : MonoBehaviour
{
    // Array untuk mini-game di kedua panel
    public GameObject[] miniGamePanel1Array; // Array untuk mini-game di panel 1
    public GameObject[] miniGamePanel2Array; // Array untuk mini-game di panel 2

    public float miniGameDuration = 15f; // Durasi setiap mini-game
    public float transitionDuration = 8f; // Waktu transisi sebelum mini-game baru terbuka
    public float transitionDurationPanel1 = 2f; // Cooldown sebelum memanggil kembali mini-game 1

    private void Start()
    {
        StartMiniGame1();
    }

    private void StartMiniGame1()
    {
        // Pilih mini-game secara acak dari panel 1
        int randomIndex1 = Random.Range(0, miniGamePanel1Array.Length);
        ActivateMiniGame(miniGamePanel1Array, randomIndex1);

        // Nonaktifkan semua mini-game di panel 2
        DeactivateAllMiniGames(miniGamePanel2Array);

        // Panggil mini-game kedua pada detik ke-8
        Invoke("StartMiniGame2", 8f);

        // Durasi total untuk mini-game pertama
        Invoke("EndMiniGame1", miniGameDuration);
    }

    private void StartMiniGame2()
    {
        // Pilih mini-game secara acak dari panel 2
        int randomIndex2 = Random.Range(0, miniGamePanel2Array.Length);
        ActivateMiniGame(miniGamePanel2Array, randomIndex2);
    }

    private void EndMiniGame1()
    {
        // Nonaktifkan semua mini-game di panel 1
        DeactivateAllMiniGames(miniGamePanel1Array);

        // Tunggu cooldown 2 detik sebelum memanggil kembali mini-game 1
        Invoke("RestartMiniGame1", transitionDurationPanel1);

        // Durasi total untuk mini-game kedua
        Invoke("EndMiniGame2", miniGameDuration); // Memanggil EndMiniGame2 setelah durasi mini-game
    }

    private void RestartMiniGame1()
    {
        StartMiniGame1();
    }

    private void EndMiniGame2()
    {
        // Nonaktifkan semua mini-game di panel 2
        DeactivateAllMiniGames(miniGamePanel2Array);

        // Kembali ke mini-game pertama setelah cooldown
        Invoke("RestartMiniGame1", transitionDurationPanel1);
    }

    private void ActivateMiniGame(GameObject[] miniGameArray, int index)
    {
        // Aktifkan mini-game yang dipilih berdasarkan indeks
        miniGameArray[index].SetActive(true);
    }

    private void DeactivateAllMiniGames(GameObject[] miniGameArray)
    {
        // Nonaktifkan semua mini-game dalam array
        foreach (GameObject miniGame in miniGameArray)
        {
            miniGame.SetActive(false);
        }
    }

    private void EndGame()
    {
        // Logika untuk mengakhiri permainan
        DeactivateAllMiniGames(miniGamePanel1Array);
        DeactivateAllMiniGames(miniGamePanel2Array);
        // Tambahkan logika tambahan untuk menampilkan hasil atau beralih ke layar akhir
    }
}
