using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{

    public Transform spawnStartPoint; // Titik awal spawn di bagian bawah
    public List<GameObject> foodItems; // List makanan dan sampah
    public List<GameObject> spawnedObjects; // List objek yang sudah di-spawn
    public int maxFoodItems = 100; // Maksimal 100 makanan
    public float spawnInterval = 1.5f; // Jarak vertikal antar makanan
    public float moveSpeed = 2f; // Kecepatan makanan naik saat makanan dikumpulkan

    private void Start()
    {
        // Spawn makanan pada awal permainan
        for (int i = 0; i < maxFoodItems; i++)
        {
            SpawnFoodItem(i);
        }
    }

    // Method untuk spawn makanan dari bawah ke atas
    private void SpawnFoodItem(int index)
    {
        if (foodItems.Count > 0)
        {
            // Memilih makanan acak dari list
            int randomIndex = Random.Range(0, foodItems.Count);
            // Spawn di posisi yang lebih rendah dari objek terakhir
            GameObject food = Instantiate(foodItems[randomIndex], spawnStartPoint.position - new Vector3(0, index * spawnInterval, 0), Quaternion.identity);

            spawnedObjects.Add(food); // Menambahkan makanan ke list spawned
        }
    }

    // Method untuk memindahkan makanan ke bawah setelah objek terdepan dikumpulkan
    public void ShiftFoodItems()
    {
        if (spawnedObjects.Count > 0)
        {
            // Hapus makanan terdepan dari list
            GameObject collectedFood = spawnedObjects[0];
            spawnedObjects.RemoveAt(0);
            Destroy(collectedFood);

            // Geser makanan yang tersisa ke bawah
            for (int i = 0; i < spawnedObjects.Count; i++)
            {
                Vector3 targetPosition = spawnStartPoint.position - new Vector3(0, i * spawnInterval, 0);
                StartCoroutine(MoveToPosition(spawnedObjects[i], targetPosition)); // Pindahkan dengan animasi
            }

            // Respawn satu makanan di bagian paling bawah
            SpawnFoodItem(spawnedObjects.Count);
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
