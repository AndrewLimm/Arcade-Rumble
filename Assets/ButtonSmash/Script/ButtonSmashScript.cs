using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSmashScript : MonoBehaviour
{
    public Slider _player1FillBar; // Referensi ke fill bar Player 1
    public Slider _player2FillBar; // Referensi ke fill bar Player 2
    public float _fillSpeed = 0.5f; // Kecepatan pengisian bar setiap kali tombol ditekan
    public GameObject building; // Objek gedung yang akan dihancurkan

    [SerializeField] GameOverManager _gameOverManager;

    void Update()
    {
        // Input untuk Player 1 (tombol 'A')
        if (Input.GetKeyDown(KeyCode.A))
        {
            _player1FillBar.value += _fillSpeed; // Tambah progress fill bar
            CheckBuildingDestroyed(_player1FillBar);
        }

        // Input untuk Player 2 (tombol 'J')
        if (Input.GetKeyDown(KeyCode.J))
        {
            _player2FillBar.value += _fillSpeed;
            CheckBuildingDestroyed(_player2FillBar);
        }
    }

    // Mengecek apakah gedung sudah hancur
    void CheckBuildingDestroyed(Slider fillBar)
    {
        if (fillBar.value >= fillBar.maxValue) // Jika bar penuh
        {
            DestroyBuilding();
        }
    }

    // Fungsi untuk menghancurkan gedung
    void DestroyBuilding()
    {
        // Logika untuk menghancurkan gedung, misalnya:
        building.SetActive(false); // Matikan objek gedung
        Debug.Log("Building Destroyed!");

        _gameOverManager.TriggerGameOver();
        // Bisa menambahkan efek hancur atau reset permainan
    }
}
