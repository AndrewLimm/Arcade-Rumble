using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpMeOutGameOver : MonoBehaviour
{
    [SerializeField] private HelpMeOUtPlayerTimeController helpMeOUtPlayerTimeController;
    [SerializeField] private TextMeshProUGUI winMessageText; // Referensi untuk TextMeshPro


    void Start()
    {
        // Menyembunyikan pesan kemenangan saat permainan dimulai
        if (winMessageText != null)
        {
            winMessageText.gameObject.SetActive(false); // Menyembunyikan teks kemenangan
            Debug.Log("Pesan kemenangan disembunyikan saat permainan dimulai.");
        }
        else
        {
            Debug.LogWarning("winMessageText tidak terhubung!");
        }
    }

    // Metode untuk memicu kondisi game over
    public void TriggerEnd(string winner)
    {
        // Menampilkan pesan pemenang
        if (winMessageText != null)
        {
            winMessageText.text = $"{winner} Win!"; // Tampilkan nama pemenang
            winMessageText.gameObject.SetActive(true); // Menampilkan teks kemenangan
        }
        else
        {
            Debug.LogWarning("winMessageText tidak terhubung!");
        }

        // Logika tambahan untuk game over, seperti menghentikan pergerakan pemain atau permainan
        Debug.Log("Game Over! Pemain telah mencapai garis akhir.");

        // Menambahkan poin kemenangan sesuai dengan pemain yang menang
        if (winner == "Player 1")
        {
            GameRumbleGameManagerForScore.instance.AddWinPoint(1);
        }
        else if (winner == "Player 2")
        {
            GameRumbleGameManagerForScore.instance.AddWinPoint(2);
        }

        // Hentikan permainan dengan menghentikan waktu (opsional)
        helpMeOUtPlayerTimeController.StopAllTimers();
        Debug.Log("Permainan dihentikan.");

        // Pindah ke scene berikutnya setelah delay
        StartCoroutine(LoadNextSceneAfterDelay());
    }
    private IEnumerator LoadNextSceneAfterDelay()
    {
        // Menunggu selama delay sebelum pindah scene
        yield return new WaitForSeconds(0.5f);

        // Pindah ke scene berikutnya (ganti "NamaSceneBerikutnya" dengan nama scene yang sesuai)
        SceneManager.LoadScene("ArcadeRumbleResultScreen");
    }
    public void LoadSpecialMiniGame()
    {
        SceneManager.LoadScene("MixMayhem"); // Ganti dengan nama scene mini-game khusus
    }
}
