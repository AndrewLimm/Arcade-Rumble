using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickTapMixMayhemplayer2EgibleInput : MonoBehaviour
{
    public KeyCode edibleCollectKeyplayer2; // Tombol untuk collect makanan edible
    public QuickTapMixMAyhemPlayer2Input player2Collect;

    private void Start()
    {
        player2Collect = FindAnyObjectByType<QuickTapMixMAyhemPlayer2Input>(); // Mengakses skrip PlayerCollect
    }

    private void Update()
    {
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
                }
                else
                {
                    player2Collect.WrongCollection(frontFood); // Jika salah, beri penalti
                }
            }
        }
    }
}
