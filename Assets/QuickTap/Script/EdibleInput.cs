using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdibleInput : MonoBehaviour
{
    public KeyCode edibleCollectKey; // Tombol untuk collect makanan edible
    private PlayerCollect playerCollect;

    private void Start()
    {
        playerCollect = FindAnyObjectByType<PlayerCollect>(); // Mengakses skrip PlayerCollect
    }

    public void StartEdibleInputCoroutine()
    {
        StartCoroutine(HandleEdibleInput());
    }

    private IEnumerator HandleEdibleInput()
    {
        while (true) // Loop untuk memeriksa input terus menerus
        {
            if (!FindObjectOfType<QuickTapTImer>().IsGameActive())
            {
                yield break; // Keluar dari coroutine jika permainan tidak aktif
            }
            // Jika pemain menekan tombol untuk collect edible
            if (Input.GetKeyDown(edibleCollectKey))
            {
                GameObject frontFood = playerCollect.GetFrontFoodInRange(); // Dapatkan makanan terdepan
                if (frontFood != null)
                {
                    if (frontFood.CompareTag("Edible"))
                    {
                        playerCollect.CollectEdible(frontFood); // Jika edible, collect
                        Debug.Log("Makanan berhasil diambil: " + frontFood.name);
                    }
                    else
                    {
                        playerCollect.WrongCollection(frontFood); // Jika salah, beri penalti
                        Debug.Log("Salah mengambil makanan: " + frontFood.name);
                    }
                }
            }

            yield return null; // Tunggu hingga frame berikutnya
        }
    }
}
