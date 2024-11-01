using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSelectionBUtton : MonoBehaviour
{
    private string selectedGameScene; // Menyimpan nama scene yang dipilih
    private Button selectedButton; // Menyimpan tombol yang dipilih

    // Daftar referensi ke tombol untuk setiap game
    [SerializeField] public Button catchItemButton;
    [SerializeField] public Button collectCoinButton;
    [SerializeField] public Button flappyAnimalButton;
    [SerializeField] public Button gameTembakButton;
    [SerializeField] public Button helpMeOutButton;
    [SerializeField] public Button jumpOverButton;
    [SerializeField] public Button karateAnimalButton;
    [SerializeField] public Button memoryMatchButton;
    [SerializeField] public Button quickMathButton;
    [SerializeField] public Button quickTapButton;
    [SerializeField] public Button MixMayhemButton;
    [SerializeField] public Button reactionTestButton;
    [SerializeField] public Button stayAliveButton;
    [SerializeField] public Button tetrisButton;

    private void Start()
    {
        ResetButtonStyles(); // Setel gaya awal untuk setiap tombol
    }

    // Fungsi untuk menyoroti tombol yang dipilih
    private void HighlightButton(Button buttonToHighlight)
    {
        ResetButtonStyles(); // Reset semua tombol terlebih dahulu

        // Ubah tampilan tombol yang dipilih
        TMP_Text buttonText = buttonToHighlight.GetComponentInChildren<TextMeshProUGUI>();
        if (buttonText != null)
        {
            buttonText.fontStyle = FontStyles.Bold; // Ubah teks menjadi bold
            buttonToHighlight.image.color = Color.yellow; // Ubah warna latar belakang tombol yang dipilih
        }

        selectedButton = buttonToHighlight; // Simpan tombol yang dipilih
    }

    // Fungsi untuk mereset style semua tombol ke tampilan default
    private void ResetButtonStyles()
    {
        Button[] buttons = {
            catchItemButton, collectCoinButton, flappyAnimalButton, gameTembakButton,
            helpMeOutButton, jumpOverButton, karateAnimalButton, memoryMatchButton,
            quickMathButton, quickTapButton, MixMayhemButton, reactionTestButton,
            stayAliveButton, tetrisButton
        };

        foreach (Button button in buttons)
        {
            TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            if (buttonText != null)
            {
                buttonText.fontStyle = FontStyles.Normal; // Kembalikan ke teks normal
                button.image.color = Color.white; // Warna default latar belakang tombol
            }
        }
    }

    // Fungsi untuk setiap tombol game yang mengatur game yang dipilih dan menyorot tombol
    public void SelectCatchItem()
    {
        selectedGameScene = "CatchItem";
        HighlightButton(catchItemButton);
    }

    public void SelectCollectTheCoin()
    {
        selectedGameScene = "CollectTheCoinScene";
        HighlightButton(collectCoinButton);
    }

    public void SelectFlappyAnimal()
    {
        selectedGameScene = "FlappyAnimal";
        HighlightButton(flappyAnimalButton);
    }

    public void SelectGameTembak()
    {
        selectedGameScene = "GameTembakDemoScene";
        HighlightButton(gameTembakButton);
    }

    public void SelectHelpMeOut()
    {
        selectedGameScene = "HelpMeOut";
        HighlightButton(helpMeOutButton);
    }

    public void SelectJumpOver()
    {
        selectedGameScene = "JumpOver";
        HighlightButton(jumpOverButton);
    }

    public void SelectKarateAnimal()
    {
        selectedGameScene = "KarateAnimal";
        HighlightButton(karateAnimalButton);
    }

    public void SelectMemoryMatch()
    {
        selectedGameScene = "MemoryMatchDemo";
        HighlightButton(memoryMatchButton);
    }

    public void SelectQuickMath()
    {
        selectedGameScene = "QuickMathDemo";
        HighlightButton(quickMathButton);
    }

    public void SelectQuickTap()
    {
        selectedGameScene = "QuickTapDemo";
        HighlightButton(quickTapButton);
    }

    public void SelectMixMayhem()
    {
        selectedGameScene = "MixMayhem";
        HighlightButton(MixMayhemButton);
    }

    public void SelectReactionTest()
    {
        selectedGameScene = "ReactionTest";
        HighlightButton(reactionTestButton);
    }

    public void SelectStayAlive()
    {
        selectedGameScene = "StayAlive";
        HighlightButton(stayAliveButton);
    }

    public void SelectTetris()
    {
        selectedGameScene = "FallingBlockScene";
        HighlightButton(tetrisButton);
    }

    // Fungsi untuk tombol "Select" yang memuat scene yang telah dipilih
    public void LoadSelectedGame()
    {
        if (!string.IsNullOrEmpty(selectedGameScene))
        {
            SceneManager.LoadScene(selectedGameScene);
        }
        else
        {
            Debug.Log("Tidak ada game yang dipilih!"); // Pesan jika belum ada game yang dipilih
        }
    }
}

