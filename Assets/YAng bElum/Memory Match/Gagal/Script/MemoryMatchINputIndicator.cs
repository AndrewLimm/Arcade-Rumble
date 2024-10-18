using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryMatchINputIndicator : MonoBehaviour
{
    public List<SpriteRenderer> lamps; // List untuk menyimpan SpriteRenderer dari lampu
    public Sprite lampOnSprite; // Sprite lampu menyala
    public Sprite lampOffSprite; // Sprite lampu mati

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
    }

    public void IndicateInput(int index)
    {
        if (index >= 0 && index < lamps.Count)
        {
            lamps[index].sprite = lampOnSprite; // Setel sprite lampu menyala sesuai index input
            Debug.Log($"Lampu {index + 1} menyala!"); // Log untuk debugging
        }
    }
}
