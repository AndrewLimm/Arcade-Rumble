// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class DemoTest : MonoBehaviour
// {
//     [SerializeField] SpawnerManager spawnerManager; // Drag the SpawnerManager component in the Inspector
//     [SerializeField] PlayerCollect player1;         // Drag the Player 1 component in the Inspector
//     [SerializeField] PlayerCollect player2;         // Drag the Player 2 component in the Inspector

//     [ContextMenu("Destroy Object")]
//     private void DestroyObject()
//     {
//         if (spawnerManager != null && spawnerManager.spawnedObjects.Count > 0)
//         {
//             GameObject objectToDestroy = spawnerManager.spawnedObjects[0]; // Ambil objek terdepan
//             spawnerManager.ObjectCollected(); // Hapus objek dan panggil respawn
//             Debug.Log("Test: Object destroyed and will respawn in " + spawnerManager.respawnTime + " seconds.");
//         }
//         else
//         {
//             Debug.LogWarning("No object is currently spawned to destroy.");
//         }
//     }

//     [ContextMenu("Simulate Player 1 Collect")]
//     private void SimulatePlayer1Collect()
//     {
//         if (player1 != null)
//         {
//             GameObject frontFood = player1.GetFrontFoodInRange(); // Dapatkan makanan terdepan
//             if (frontFood != null)
//             {
//                 if (frontFood.CompareTag("Edible"))
//                 {
//                     player1.CollectEdible(frontFood); // Simulasikan pengumpulan makanan edible
//                     Debug.Log("Simulated Player 1 Collecting Edible Object.");
//                 }
//                 else if (frontFood.CompareTag("Trash"))
//                 {
//                     player1.CollectTrash(frontFood); // Simulasikan pengumpulan sampah
//                     Debug.Log("Simulated Player 1 Collecting Trash Object.");
//                 }
//                 else
//                 {
//                     player1.WrongCollection(frontFood); // Simulasikan kesalahan pengumpulan
//                     Debug.Log("Simulated Player 1 Collecting Wrong Object.");
//                 }
//             }
//         }
//     }

//     [ContextMenu("Simulate Player 2 Collect")]
//     private void SimulatePlayer2Collect()
//     {
//         if (player2 != null)
//         {
//             GameObject frontFood = player2.GetFrontFoodInRange(); // Dapatkan makanan terdepan
//             if (frontFood != null)
//             {
//                 if (frontFood.CompareTag("Edible"))
//                 {
//                     player2.CollectEdible(frontFood); // Simulasikan pengumpulan makanan edible
//                     Debug.Log("Simulated Player 2 Collecting Edible Object.");
//                 }
//                 else if (frontFood.CompareTag("Trash"))
//                 {
//                     player2.CollectTrash(frontFood); // Simulasikan pengumpulan sampah
//                     Debug.Log("Simulated Player 2 Collecting Trash Object.");
//                 }
//                 else
//                 {
//                     player2.WrongCollection(frontFood); // Simulasikan kesalahan pengumpulan
//                     Debug.Log("Simulated Player 2 Collecting Wrong Object.");
//                 }
//             }
//         }
//     }
// }
