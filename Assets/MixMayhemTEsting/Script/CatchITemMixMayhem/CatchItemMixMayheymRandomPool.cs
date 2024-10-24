using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchItemMixMayheymRandomPool : MonoBehaviour
{
    public List<GameObject> itemPool = new List<GameObject>();

    // Fungsi untuk merandom item dari pool
    public GameObject GetRandomItem()
    {
        if (itemPool.Count == 0)
        {
            Debug.LogError("Item Pool is empty!");
            return null;
        }

        int randomIndex = Random.Range(0, itemPool.Count);
        return itemPool[randomIndex];
    }
}
