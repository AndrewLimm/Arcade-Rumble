using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchItemMixMayhemDIsableOnhitplayer1 : MonoBehaviour
{
    [SerializeField] CatchItemCollectible _collectible;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1Collector"))
        {
            // Tambahkan skor untuk Player 1
            CtachItemMixmayhemScoreManagerplayer1.instance.AddScore(_collectible.value);
            _collectible.TriggerCollection(collision.gameObject);
            gameObject.SetActive(false); // Nonaktifkan collectible setelah dikumpulkan
        }
    }
}
