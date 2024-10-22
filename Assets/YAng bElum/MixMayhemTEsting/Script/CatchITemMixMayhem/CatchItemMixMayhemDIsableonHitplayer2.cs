using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchItemMixMayhemDIsableonHitplayer2 : MonoBehaviour
{
    [SerializeField] CatchItemCollectible _collectible;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Memeriksa apakah collider adalah Player 2
        if (collision.CompareTag("Player2Collector"))
        {
            // Tambahkan skor untuk Player 2
            catchitemMixmayhemscoremanagerplayer2.instance.AddScore(_collectible.value);
            _collectible.TriggerCollection(collision.gameObject);
            gameObject.SetActive(false); // Nonaktifkan collectible setelah dikumpulkan
        }
    }
}
