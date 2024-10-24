using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchItemMixMayhemRandomRequestor : MonoBehaviour
{
    public CatchItemMixMayheymRandomPool randomPool; // Referensi ke Random Pool

    // Fungsi untuk meminta item acak dari pool
    public GameObject RequestRandomItem()
    {
        if (randomPool != null)
        {
            return randomPool.GetRandomItem();
        }
        else
        {
            Debug.LogError("RandomPool is not assigned in PoolRequestor.");
            return null;
        }
    }
}
