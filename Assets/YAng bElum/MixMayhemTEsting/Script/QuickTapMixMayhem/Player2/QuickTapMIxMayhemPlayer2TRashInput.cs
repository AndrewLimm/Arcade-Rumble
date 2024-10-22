using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickTapMIxMayhemPlayer2TRashInput : MonoBehaviour
{
    public KeyCode trashCollectKeyplayer2; // Tombol untuk collect sampah
    public QuickTapMixMAyhemPlayer2Input player2Collect;

    private void Start()
    {
        player2Collect = FindAnyObjectByType<QuickTapMixMAyhemPlayer2Input>(); // Mengakses skrip PlayerCollect
    }

    private void Update()
    {
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
                }
                else
                {
                    player2Collect.WrongCollection(frontFood); // Jika salah, beri penalti
                }
            }
        }
    }
}
