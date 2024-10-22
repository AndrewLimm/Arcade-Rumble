using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixMayhemRandonPool : MonoBehaviour
{
    // Daftar game untuk Panel 1 dan Panel 2
    public List<GameObject> panel1Games = new List<GameObject>();
    public List<GameObject> panel2Games = new List<GameObject>();

    // Fungsi untuk mendapatkan game acak dari panel 1
    public GameObject GetRandomPanel1Game()
    {
        int randomIndex = Random.Range(0, panel1Games.Count);
        return panel1Games[randomIndex];
    }

    // Fungsi untuk mendapatkan game acak dari panel 2
    public GameObject GetRandomPanel2Game()
    {
        int randomIndex = Random.Range(0, panel2Games.Count);
        return panel2Games[randomIndex];
    }
}
