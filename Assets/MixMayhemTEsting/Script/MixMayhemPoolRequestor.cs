using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixMayhemPoolRequestor : MonoBehaviour
{
    [SerializeField] public MixMayhemRandonPool randomPool;

    // Fungsi untuk meminta game acak dari panel 1
    public GameObject RequestPanel1Game()
    {
        return randomPool.GetRandomPanel1Game();
    }

    // Fungsi untuk meminta game acak dari panel 2
    public GameObject RequestPanel2Game()
    {
        return randomPool.GetRandomPanel2Game();
    }
}
