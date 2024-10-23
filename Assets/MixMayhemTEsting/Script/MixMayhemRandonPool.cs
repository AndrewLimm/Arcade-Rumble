using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixMayhemRandonPool : MonoBehaviour
{
    // List yang diisi di Inspector
    public List<GameObject> panel1Games;
    public List<GameObject> panel2Games;

    // Pool internal untuk melacak game yang belum dan sudah dimainkan
    private List<GameObject> availablePanel1Games = new List<GameObject>();
    private List<GameObject> usedPanel1Games = new List<GameObject>();
    private List<GameObject> availablePanel2Games = new List<GameObject>();
    private List<GameObject> usedPanel2Games = new List<GameObject>();

    private void Start()
    {
        // Inisialisasi pool dengan game yang ditambahkan via Inspector
        ResetPanel1Pool();
        ResetPanel2Pool();
    }

    public GameObject GetRandomPanel1Game()
    {
        if (availablePanel1Games.Count == 0)
        {
            ResetPanel1Pool();
        }

        int randomIndex = Random.Range(0, availablePanel1Games.Count);
        GameObject selectedGame = availablePanel1Games[randomIndex];

        availablePanel1Games.RemoveAt(randomIndex);
        usedPanel1Games.Add(selectedGame);

        return selectedGame;
    }

    public GameObject GetRandomPanel2Game()
    {
        if (availablePanel2Games.Count == 0)
        {
            ResetPanel2Pool();
        }

        int randomIndex = Random.Range(0, availablePanel2Games.Count);
        GameObject selectedGame = availablePanel2Games[randomIndex];

        availablePanel2Games.RemoveAt(randomIndex);
        usedPanel2Games.Add(selectedGame);

        return selectedGame;
    }

    public void ResetPanel1Pool()
    {
        availablePanel1Games.Clear();
        availablePanel1Games.AddRange(panel1Games);  // Mengisi dari list yang sudah ditambahkan di Inspector
        usedPanel1Games.Clear();
    }

    public void ResetPanel2Pool()
    {
        availablePanel2Games.Clear();
        availablePanel2Games.AddRange(panel2Games);  // Mengisi dari list yang sudah ditambahkan di Inspector
        usedPanel2Games.Clear();
    }
}
