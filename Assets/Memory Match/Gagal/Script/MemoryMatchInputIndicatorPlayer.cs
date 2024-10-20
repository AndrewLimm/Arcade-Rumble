using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryMatchInputIndicatorPlayer : MonoBehaviour
{
    public List<SpriteRenderer> lamps; // List untuk menyimpan SpriteRenderer dari lampu
    public Sprite lampOnSprite; // Sprite lampu menyala
    public Sprite lampOffSprite; // Sprite lampu mati
    private int lampCount; // Menghitung jumlah lampu yang menyala

    private void Start()
    {
        ResetLamps(); // Reset semua lampu ke kondisi mati di awal permainan
    }

    public void ResetLamps()
    {
        foreach (var lamp in lamps)
        {
            lamp.sprite = lampOffSprite; // Setel sprite lampu mati
        }
        lampCount = 0; // Reset hitungan lampu yang menyala
    }

    public void IndicateInput(int index)
    {
        if (index >= 0 && index < lamps.Count)
        {
            lamps[index].sprite = lampOnSprite; // Setel sprite lampu menyala sesuai index input
            lampCount++; // Tambahkan hitungan lampu yang menyala
            Debug.Log($"Lampu Player 2 ke-{index + 1} menyala!");

            // Jika semua lampu sudah menyala, reset lampu kembali ke keadaan mati
            if (lampCount >= lamps.Count)
            {
                ResetLamps();
                Debug.Log("Semua lampu Player 2 menyala, reset lampu!");
            }
        }
    }
}
