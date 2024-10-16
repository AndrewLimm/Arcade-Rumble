using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickTapPlayer2Spawner : MonoBehaviour
{
    public Transform spawnStartPoint; // Titik awal spawn di bagian bawah
    public List<GameObject> foodItemsPlayer2; // List makanan dan sampah khusus Player 2
    public List<GameObject> spawnedObjectsPlayer2; // List objek yang sudah di-spawn khusus Player 2
    public int maxFoodItems = 100; // Maksimal 100 makanan untuk Player 2
    public float spawnInterval = 1.5f; // Jarak vertikal antar makanan
    public float moveSpeed = 2f; // Kecepatan makanan naik saat makanan dikumpulkan

    private void Start()
    {
        // Spawn makanan pada awal permainan untuk Player 2
        for (int i = 0; i < maxFoodItems; i++)
        {
            SpawnFoodItem(i);
        }
    }

    // Method untuk spawn makanan dari bawah ke atas khusus Player 2
    private void SpawnFoodItem(int index)
    {
        if (foodItemsPlayer2.Count > 0)
        {
            // Memilih makanan acak dari list khusus Player 2
            int randomIndex = Random.Range(0, foodItemsPlayer2.Count);
            // Spawn di posisi yang lebih rendah dari objek terakhir
            GameObject food = Instantiate(foodItemsPlayer2[randomIndex], spawnStartPoint.position - new Vector3(0, index * spawnInterval, 0), Quaternion.identity);

            spawnedObjectsPlayer2.Add(food); // Menambahkan makanan ke list spawned khusus Player 2
        }
    }

    // Method untuk memindahkan makanan ke bawah setelah objek terdepan dikumpulkan oleh Player 2
    public void ShiftFoodItems()
    {
        if (spawnedObjectsPlayer2.Count > 0)
        {
            // Hapus makanan terdepan dari list khusus Player 2
            GameObject collectedFood = spawnedObjectsPlayer2[0];
            spawnedObjectsPlayer2.RemoveAt(0);
            Destroy(collectedFood);

            // Geser makanan yang tersisa ke bawah
            for (int i = 0; i < spawnedObjectsPlayer2.Count; i++)
            {
                Vector3 targetPosition = spawnStartPoint.position - new Vector3(0, i * spawnInterval, 0);
                StartCoroutine(MoveToPosition(spawnedObjectsPlayer2[i], targetPosition)); // Pindahkan dengan animasi
            }

            // Respawn satu makanan di bagian paling bawah
            SpawnFoodItem(spawnedObjectsPlayer2.Count);
        }
    }

    // Coroutine untuk animasi pergerakan makanan
    private IEnumerator MoveToPosition(GameObject food, Vector3 targetPosition)
    {
        if (food == null) yield break; // Pastikan objek belum dihancurkan

        float elapsedTime = 0;
        float duration = 0.5f; // Lama perpindahan (set ke nilai yang diinginkan)
        Vector3 startingPosition = food.transform.position;

        while (elapsedTime < duration)
        {
            if (food == null) yield break; // Cek kembali jika objek sudah dihancurkan

            food.transform.position = Vector3.Lerp(startingPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Set posisi akhir untuk memastikan objek benar-benar sampai di target
        if (food != null)
        {
            food.transform.position = targetPosition;
        }
    }
}
