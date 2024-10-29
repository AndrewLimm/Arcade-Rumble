using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchItemCollectibleOnHIt : MonoBehaviour
{
    [SerializeField] CatchItemCollectible _collectible;
    private CatchItemScoreManagerPlayer1 _scoreManagerPlayer1;

    private void Start()
    {
        // Mengambil referensi ke CatchItemScoreManagerPlayer1 di scene
        _scoreManagerPlayer1 = FindObjectOfType<CatchItemScoreManagerPlayer1>();
        if (_scoreManagerPlayer1 == null)
        {
            Debug.LogError("CatchItemScoreManagerPlayer1 is missing in the scene.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1Collector") && _scoreManagerPlayer1 != null)
        {
            // Tambahkan skor untuk Player 1
            _scoreManagerPlayer1.AddScore(_collectible.value);
            _collectible.TriggerCollection(collision.gameObject);
            gameObject.SetActive(false); // Nonaktifkan collectible setelah dikumpulkan
        }
    }
}
