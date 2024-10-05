using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchItemBotMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Kecepatan gerakan bot
    public float leftBoundary = -7f; // Batas kiri
    public float rightBoundary = 7f; // Batas kanan
    private Vector3 moveDirection = Vector3.right; // Arah gerakan (ke kanan)

    void Update()
    {
        // Gerakkan bot terus ke kanan
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Jika bot mencapai batas kanan, balik ke kiri
        if (transform.position.x >= rightBoundary)
        {
            moveDirection = Vector3.left;
        }
        // Jika bot mencapai batas kiri, balik ke kanan
        else if (transform.position.x <= leftBoundary)
        {
            moveDirection = Vector3.right;
        }
    }
}
