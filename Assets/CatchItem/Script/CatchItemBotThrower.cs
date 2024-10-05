using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchItemBotThrower : MonoBehaviour
{
    public Transform throwPoint; // Titik di mana barang dilempar
    public float throwInterval = 2f; // Waktu interval antar lemparan
    public float throwForce = 5f; // Kekuatan lemparan
    public float itemLifetime = 3f; //Waktu sebelum objek dihancurkan

    [SerializeField] CatchItemRandomRequestor catchItemRandomRequestor;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        // Lempar barang setelah interval waktu tertentu
        if (timer >= throwInterval)
        {
            ThrowItem();
            timer = 0f;
        }
    }

    void ThrowItem()
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
