using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickTapPlayer2Spawner : MonoBehaviour
{
    public Transform spawnStartPoint; // Titik awal spawn di bagian bawah
    public List<GameObject> foodItemsplayer2; // List makanan dan sampah
    public List<GameObject> spawnedObjectplayer2; // List objek yang sudah di-spawn
    public int maxFoodItems = 100; // Maksimal 100 makanan
    public float spawnInterval = 1.5f; // Jarak vertikal antar makanan
    public float moveSpeed = 2f; // Kecepatan makanan turun saat makanan dikumpulkan

    private void Start()
    {
        // Spawn makanan pada awal permainan
        for (int i = 0; i < maxFoodItems; i++)
        {
            SpawnFoodItem(i);
        }
    }

    // Method untuk spawn makanan
    private void SpawnFoodItem(int index)
    {
        if (foodItemsplayer2.Count > 0)
        {
            // Memilih makanan acak dari list
            int randomIndex = Random.Range(0, foodItemsplayer2.Count);
            // Spawn di posisi yang lebih tinggi dari objek terakhir
            GameObject food = Instantiate(foodItemsplayer2[randomIndex], spawnStartPoint.position + new Vector3(0, index * spawnInterval, 0), Quaternion.identity);

            spawnedObjectplayer2.Add(food); // Menambahkan makanan ke list spawned
        }
    }

    // Method untuk memindahkan makanan ke atas setelah objek terdepan dikumpulkan
    public void ShiftFoodItems()
    {
        if (spawnedObjectplayer2.Count > 0)
        {
            // Hapus makanan terdepan dari list
            GameObject collectedFood = spawnedObjectplayer2[0];
            spawnedObjectplayer2.RemoveAt(0);
            Destroy(collectedFood);

            // Geser makanan yang tersisa ke atas
            for (int i = 0; i < spawnedObjectplayer2.Count; i++)
            {
                Vector3 targetPosition = spawnStartPoint.position + new Vector3(0, (i) * spawnInterval, 0);
                StartCoroutine(MoveToPosition(spawnedObjectplayer2[i], targetPosition)); // Pindahkan dengan animasi
            }

            // Respawn satu makanan di bagian paling bawah
            SpawnFoodItem(spawnedObjectplayer2.Count);
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
