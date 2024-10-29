using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchItemCollectibleOnHitPlayer2 : MonoBehaviour
{
    [SerializeField] private CatchItemCollectible _collectible;
    private CatchItemScoreManagerPlayer2 _scoreManagerPlayer2;

    private void Start()
    {
        // Mengambil referensi ke CatchItemScoreManagerPlayer2 di scene
        _scoreManagerPlayer2 = FindObjectOfType<CatchItemScoreManagerPlayer2>();
        if (_scoreManagerPlayer2 == null)
        {
            Debug.LogError("CatchItemScoreManagerPlayer2 is missing in the scene.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player2Collector") && _scoreManagerPlayer2 != null)
        {
            // Tambahkan skor untuk Player 2
            _scoreManagerPlayer2.AddScore(_collectible.value);
            _collectible.TriggerCollection(collision.gameObject);
            gameObject.SetActive(false); // Nonaktifkan collectible setelah dikumpulkan
        }
    }
}
