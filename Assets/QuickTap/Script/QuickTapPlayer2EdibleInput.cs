using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickTapPlayer2EdibleInput : MonoBehaviour
{
    public KeyCode edibleCollectKeyplayer2; // Tombol untuk collect makanan edible
    public QuickTapPlayer2Input player2Collect;

    private void Start()
    {
        player2Collect = FindAnyObjectByType<QuickTapPlayer2Input>(); // Mengakses skrip PlayerCollect
    }

    public void StartPlayer2EdibleInputCoroutine()
    {
        StartCoroutine(HandlePlayer2EdibleInput());
    }

    private IEnumerator HandlePlayer2EdibleInput()
    {
        while (true) // Loop untuk memeriksa input terus menerus
        {
            if (!FindObjectOfType<QuickTapTImer>().IsGameActive())
            {
                yield break; // Keluar dari coroutine jika permainan tidak aktif
            }
            
            // Jika pemain menekan tombol untuk collect edible
            if (Input.GetKeyDown(edibleCollectKeyplayer2))
            {
                Debug.Log("Tombol collect edible ditekan.");
                GameObject frontFood = player2Collect.GetFrontFoodInRange(); // Dapatkan makanan terdepan
                if (frontFood != null)
                {
                    if (frontFood.CompareTag("Edible"))
                    {
                        player2Collect.CollectEdible(frontFood); // Jika edible, collect
                        Debug.Log("Edible collected: " + frontFood.name);
                    }
                    else
                    {
                        player2Collect.WrongCollection(frontFood); // Jika salah, beri penalti
                        Debug.Log("Salah mengambil objek: " + frontFood.name);
                    }
                }
            }

            yield return null; // Tunggu hingga frame berikutnya
        }
    }
}
