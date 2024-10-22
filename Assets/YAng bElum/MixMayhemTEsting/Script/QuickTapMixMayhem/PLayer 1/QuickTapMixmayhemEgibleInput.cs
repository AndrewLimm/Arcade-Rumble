using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickTapMixmayhemEgibleInput : MonoBehaviour
{
    public KeyCode edibleCollectKey; // Tombol untuk collect makanan edible
    private QuickTapMixMayhemPlayer1Input playerCollect;

    private void Start()
    {
        playerCollect = FindAnyObjectByType<QuickTapMixMayhemPlayer1Input>(); // Mengakses skrip PlayerCollect
    }

    private void Update()
    {
        // Jika pemain menekan tombol untuk collect edible
        if (Input.GetKeyDown(edibleCollectKey))
        {
            GameObject frontFood = playerCollect.GetFrontFoodInRange(); // Dapatkan makanan terdepan
            if (frontFood != null)
            {
                if (frontFood.CompareTag("Edible"))
                {
                    playerCollect.CollectEdible(frontFood); // Jika edible, collect
                }
                else
                {
                    playerCollect.WrongCollection(frontFood); // Jika salah, beri penalti
                }
            }
        }
    }
}
