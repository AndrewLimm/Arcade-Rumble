using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryMatchGameManager : MonoBehaviour
{
    public static MemoryMatchGameManager instance;

    public Sprite[] cardSprites; // Array untuk menyimpan gambar kartu
    public Sprite faceDownCard; // Gambar kartu yang dibalik

    private MemoryGameCad firstCard, secondCard;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        SetupGame();
    }

    void SetupGame()
    {
        // Logika untuk mengacak kartu dan menempatkannya di grid
        // Pastikan untuk menyiapkan kartu dengan ID yang benar
    }

    public bool CanFlip()
    {
        return secondCard == null;
    }

    public void CheckForMatch(MemoryGameCad card)
    {
        if (firstCard == null)
        {
            firstCard = card; // Simpan kartu pertama yang dibalik
        }
        else
        {
            secondCard = card; // Simpan kartu kedua yang dibalik
            StartCoroutine(CheckMatch());
        }
    }

    private IEnumerator CheckMatch()
    {
        yield return new WaitForSeconds(1f); // Tunggu sebentar untuk melihat kartu

        if (firstCard.id == secondCard.id)
        {
            // Kartu cocok
            Debug.Log("Match!");
            // Tambahkan logika untuk menghapus kartu yang cocok
        }
        else
        {
            // Kartu tidak cocok, kembalikan
            firstCard.ResetCard();
            secondCard.ResetCard();
        }

        firstCard = null;
        secondCard = null;
    }
}
