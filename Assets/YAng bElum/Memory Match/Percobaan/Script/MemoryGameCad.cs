using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryGameCad : MonoBehaviour
{
    public int id; // ID kartu untuk mencocokkan
    private bool isFlipped = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Set the card to be initially face down
        spriteRenderer.sprite = MemoryMatchGameManager.instance.faceDownCard;
    }

    void OnMouseDown()
    {
        if (!isFlipped && MemoryMatchGameManager.instance.CanFlip())
        {
            FlipCard();
            MemoryMatchGameManager.instance.CheckForMatch(this);
        }
    }

    public void FlipCard()
    {
        isFlipped = true;
        spriteRenderer.sprite = MemoryMatchGameManager.instance.cardSprites[id]; // Ganti dengan gambar kartu
    }

    public void ResetCard()
    {
        isFlipped = false;
        spriteRenderer.sprite = MemoryMatchGameManager.instance.faceDownCard;
    }
}
