using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageDisplay : MonoBehaviour
{
    public List<SpriteRenderer> spriteRenderers = new List<SpriteRenderer>(); // List dari komponen SpriteRenderer
    public List<Sprite> sprites = new List<Sprite>(); // List dari sprite yang akan ditampilkan
    public float _displayTime = 5f; // Waktu untuk menampilkan sprite

    private bool _isGameStarted = false; // Flag untuk memastikan game sudah dimulai

    public void StartGame()
    {
        _isGameStarted = true; // Tandai bahwa game sudah dimulai
        StartCoroutine(DisplaySprites());
    }

    IEnumerator DisplaySprites()
    {
        // Tampilkan sprite
        for (int i = 0; i < spriteRenderers.Count; i++)
        {
            if (i < sprites.Count)
            {
                spriteRenderers[i].sprite = sprites[i]; // Ganti sprite yang ditampilkan di SpriteRenderer
            }
        }

        // Tunggu selama displayTime detik
        yield return new WaitForSeconds(_displayTime);

        // Sembunyikan sprite dengan mengosongkan SpriteRenderer
        foreach (var spriteRenderer in spriteRenderers)
        {
            spriteRenderer.sprite = null; // Menghilangkan sprite dengan set null
        }
        // Aktifkan input pemain di sini
    }

    public bool IsGameStarted()
    {
        return _isGameStarted;
    }
}
