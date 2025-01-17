using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuickMathMIxmayhemLogic : MonoBehaviour
{
    public QuickMathRandomRequestor randomRequestor;
    public TMP_Text soalText; // Text for displaying the question
    public TMP_Text[] pilihanJawabanTexts; // Array of TextMeshProUGUI for answer options
    private Soal soalAktif;

    [SerializeField] QuickMathMixMayhemScoreManager scoreManager;

    private bool isAnswered = false; // Prevents multiple inputs
    private bool gameEnded = false;  // Stops input after the game ends

    void Start()
    {
        MulaiPermainan();
    }

    public void MulaiPermainan()
    {
        scoreManager.ResetSkor();
        RequestSoalBaru();
        gameEnded = false;   // Reset game status
    }

    public void RequestSoalBaru()
    {
        if (gameEnded) return;  // Stop requesting new questions if the game has ended

        soalAktif = randomRequestor.RequestSoal();
        if (soalAktif == null)
        {
            Debug.LogError("Tidak ada soal yang tersedia.");
            return;
        }

        UpdateUI();
        isAnswered = false;  // Reset the answer status for each new question
    }

    private void UpdateUI()
    {
        soalText.text = soalAktif.pertanyaan; // Display the question text

        // Create a list of answers including the correct one and the wrong ones
        List<string> pilihanJawaban = new List<string> { soalAktif.jawabanBenar };
        pilihanJawaban.AddRange(soalAktif.jawabanSalah);

        // Shuffle the list of answers
        pilihanJawaban.Shuffle(); // Assuming you have a shuffle method for lists

        // Display the answers in the UI
        for (int i = 0; i < pilihanJawabanTexts.Length; i++)
        {
            if (i < pilihanJawaban.Count)
            {
                pilihanJawabanTexts[i].text = pilihanJawaban[i];
                pilihanJawabanTexts[i].gameObject.SetActive(true);
            }
            else
            {
                pilihanJawabanTexts[i].gameObject.SetActive(false);
            }
        }
    }

    // Handle player input, only one player can answer each question
    public void CekJawaban(int pilihanDipilih, int pemain)
    {
        if (gameEnded) return;  // Stop input if the game has ended
        if (isAnswered) return; // Check if the question has already been answered

        if (soalAktif != null)
        {
            string jawabanDipilih = pilihanJawabanTexts[pilihanDipilih].text;
            bool benar = jawabanDipilih == soalAktif.jawabanBenar;

            if (benar)
            {
                isAnswered = true;  // Mark the question as answered

                // The player who answers first gets points
                if (pemain == 1)
                {
                    scoreManager.TambahSkorPemain1(scoreManager.poinBenar);
                    Debug.Log("Player 1 mendapat poin!");
                }
                else if (pemain == 2)
                {
                    scoreManager.TambahSkorPemain2(scoreManager.poinBenar);
                    Debug.Log("Player 2 mendapat poin!");
                }

                StartCoroutine(JedaSebelumSoalBaru());
            }
        }
    }

    private IEnumerator JedaSebelumSoalBaru()
    {
        yield return new WaitForSeconds(1f); // Ganti jeda sesuai kebutuhan
        if (!gameEnded)
        {
            RequestSoalBaru();  // Request a new question if the game is not over
        }
    }

    // Function to end the game when needed
    private void AkhiriPermainan()
    {
        Debug.Log("Permainan selesai.");
        gameEnded = true;  // Mark the game as ended to stop all input
        // You can add additional logic here, such as displaying the final results UI.
    }
}
