using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickTapMixMayhemPlayer1TrashInput : MonoBehaviour
{
    public KeyCode trashCollectKey; // Tombol untuk collect sampah
    private QuickTapMixMayhemPlayer1Input playerCollect;

    private void Start()
    {
        playerCollect = FindAnyObjectByType<QuickTapMixMayhemPlayer1Input>(); // Mengakses skrip PlayerCollect
    }

    private void Update()
    {
        // Jika pemain menekan tombol untuk collect trash
        if (Input.GetKeyDown(trashCollectKey))
        {
            GameObject frontFood = playerCollect.GetFrontFoodInRange(); // Dapatkan makanan terdepan
            if (frontFood != null)
            {
                if (frontFood.CompareTag("Trash"))
                {
                    playerCollect.CollectTrash(frontFood); // Jika trash, collect
                }
                else
                {
                    playerCollect.WrongCollection(frontFood); // Jika salah, beri penalti
                }
            }
        }
    }
}
