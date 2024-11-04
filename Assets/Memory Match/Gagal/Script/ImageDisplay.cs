using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageDisplay : MonoBehaviour
{
    public List<SpriteRenderer> spriteRenderers = new List<SpriteRenderer>(); // List dari komponen SpriteRenderer
    public List<Sprite> sprites = new List<Sprite>(); // List dari sprite yang akan ditampilkan
    public float _displayTimePerSprite = 2f; // Waktu untuk menampilkan sprite

    private bool _isGameStarted = false; // Flag untuk memastikan game sudah dimulai
    private List<int> _shuffledIndices = new List<int>(); // Indices yang diacak dari sprites

    public void StartGame()
    {
        _isGameStarted = true; // Tandai bahwa game sudah dimulai
        StartCoroutine(DisplaySprites());
    }

    public IEnumerator DisplaySprites()
    {
        List<int> indices = new List<int> { 0, 1, 2 };
        Shuffle(indices);
        _shuffledIndices = indices;

        // Tampilkan sprite satu per satu berdasarkan urutan yang diacak
        for (int i = 0; i < indices.Count; i++)
        {
            spriteRenderers[indices[i]].sprite = sprites[indices[i]];

            // Tampilkan sprite selama waktu yang ditentukan
            yield return new WaitForSeconds(_displayTimePerSprite);

            // Sembunyikan sprite setelah waktu ditampilkan
            spriteRenderers[indices[i]].sprite = null;
        }

        _isGameStarted = false; // Tandai bahwa soal selesai
    }

    void Shuffle(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(0, list.Count);
            int temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    public bool IsGameStarted()
    {
        return _isGameStarted;
    }

    public List<int> GetShuffledIndices()
    {
        return _shuffledIndices;
    }

    public void CheckAnswer(bool playerAnsweredCorrectly)
    {
        if (playerAnsweredCorrectly && !_isGameStarted)
        {
            StartGame(); // Memulai soal baru hanya jika jawaban benar
        }
    }
}
