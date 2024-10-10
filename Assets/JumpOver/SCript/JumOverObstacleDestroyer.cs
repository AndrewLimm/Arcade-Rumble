using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumOverObstacleDestroyer : MonoBehaviour
{
    public Transform destroyPoint; // Referensi ke titik penghancur

    private void Update()
    {
        // Periksa apakah obstacle telah melewati titik destroy
        if (transform.position.x < destroyPoint.position.x)
        {
            Destroy(gameObject); // Hancurkan obstacle
        }
    }
}
