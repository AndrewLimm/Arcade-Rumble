using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchItemBotThrower : MonoBehaviour
{

    public Transform throwPoint; // Titik di mana barang dilempar
    public float throwInterval = 2f; // Waktu interval antar lemparan
    public float throwForce = 5f; // Kekuatan lemparan
    public float itemLifetime = 3f; // Waktu sebelum objek dihancurkan

    [SerializeField] CatchItemRandomRequestor catchItemRandomRequestor; // Referensi ke pengambil item acak
    private float timer;
    private bool isThrowing = false; // Status apakah sedang melempar item

    void Update()
    {
        if (isThrowing)
        {
            timer += Time.deltaTime;

            // Lempar barang setelah interval waktu tertentu
            if (timer >= throwInterval)
            {
                ThrowItem();
                timer = 0f;
            }
        }
    }

    public void StartThrowing()
    {
        isThrowing = true; // Memulai pelemparan item
        timer = 0f; // Reset timer saat mulai
    }

    public void StopThrowing()
    {
        isThrowing = false; // Menghentikan pelemparan item
    }

    private void ThrowItem()
    {
        GameObject randomItem = catchItemRandomRequestor.RequestRandomItem();

        if (randomItem != null)
        {
            // Spawn item di posisi lemparan
            GameObject item = Instantiate(randomItem, throwPoint.position, Quaternion.identity);

            // Beri item kekuatan lemparan
            Rigidbody2D rb = item.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.down * throwForce;
            }

            // Hancurkan item setelah waktu hidup (itemLifetime)
            Destroy(item, itemLifetime);
        }
        else
        {
            Debug.LogError("No item found in the pool.");
        }
    }
}
