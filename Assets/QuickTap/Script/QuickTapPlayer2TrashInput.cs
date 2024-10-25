using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickTapPlayer2TrashInput : MonoBehaviour
{
    public KeyCode trashCollectKeyplayer2; // Tombol untuk collect sampah
    public QuickTapPlayer2Input player2Collect;

    private void Start()
    {
        player2Collect = FindAnyObjectByType<QuickTapPlayer2Input>(); // Mengakses skrip PlayerCollect
    }

    public void StartPlayer2TrashInputCoroutine()
    {
        StartCoroutine(HandlePlayer2TrashInput());
    }

    private IEnumerator HandlePlayer2TrashInput()
    {
        while (true) // Loop untuk memeriksa input terus menerus
        {
            if (!FindObjectOfType<QuickTapTImer>().IsGameActive())
            {
                yield break; // Keluar dari coroutine jika permainan tidak aktif
            }
            
            // Jika pemain menekan tombol untuk collect trash
            if (Input.GetKeyDown(trashCollectKeyplayer2))
            {
                Debug.Log("Tombol collect trash ditekan.");
                GameObject frontFood = player2Collect.GetFrontFoodInRange(); // Dapatkan makanan terdepan
                if (frontFood != null)
                {
                    if (frontFood.CompareTag("Trash"))
                    {
                        player2Collect.CollectTrash(frontFood); // Jika trash, collect
                        Debug.Log("Trash collected: " + frontFood.name);
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
