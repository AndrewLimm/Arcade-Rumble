using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickMathMixMayhemGameOverManager : MonoBehaviour
{
    [SerializeField] private QuickMathMixMayhemScoreManager scoreManager;
    [SerializeField] private MixMayhemPlayerLifeManager lifeManager;
    [SerializeField] private List<GameObject> miniGameObjects; // Daftar objek yang perlu dihentikan dalam mini-game (misalnya pemain, objek game)

    public void TriggerEnd(string playerTag)
    {
        // Periksa pemain yang kalah berdasarkan tag
        if (scoreManager.skorPemain1 < scoreManager.skorPemain2)
        {
            lifeManager.DamagePlayer1();
        }
        else if (scoreManager.skorPemain2 < scoreManager.skorPemain1)
        {
            Debug.Log("Pemain 2 kalah, nyawa berkurang!");
            lifeManager.DamagePlayer2();  // Kurangi nyawa Pemain 2 di MixMayhem
        }

        StopMiniGame();
        ActivateMiniGameObjects(); // Mengaktifkan kembali objek setelah stop

    }

    private void StopMiniGame()
    {
        Debug.Log($"MiniGameObjects Count: {miniGameObjects.Count}"); // Log jumlah objek

        foreach (GameObject miniGameObj in miniGameObjects)
        {
            Debug.Log($"Menonaktifkan: {miniGameObj.name}"); // Log nama objek
            SetActiveRecursively(miniGameObj, false); // Nonaktifkan semua objek
        }
    }

    // Fungsi untuk mengaktifkan objek mini-game
    public void ActivateMiniGameObjects()
    {
        foreach (GameObject miniGameObj in miniGameObjects)
        {
            Debug.Log($"Mengaktifkan kembali: {miniGameObj.name}"); // Log nama objek
            miniGameObj.SetActive(true); // Mengaktifkan parent
            SetActiveRecursively(miniGameObj, true); // Mengaktifkan semua child
        }
    }

    // Fungsi untuk menonaktifkan semua child objects secara rekursif
    private void SetActiveRecursively(GameObject parentObj, bool active)
    {
        foreach (Transform child in parentObj.transform)
        {
            child.gameObject.SetActive(active); // Nonaktifkan atau aktifkan child
            Debug.Log($"Child {child.gameObject.name} set active: {active}"); // Debug log
        }
    }
}
