using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollecCoinCoinDIsable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1Collector") || other.CompareTag("Player2Collector"))
        {
            // Pemain telah mengklaim koin, hancurkan objek koin
            Destroy(gameObject);
        }
    }
}
