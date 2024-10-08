using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayAlivePlayer1Controller : MonoBehaviour
{
    public float speed = 5f; // Adjust the movement speed

    void Update()
    {
        // Player 1 movement (WASD)
        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(KeyCode.W)) vertical = 1f;
        if (Input.GetKey(KeyCode.S)) vertical = -1f;
        if (Input.GetKey(KeyCode.A)) horizontal = -1f;
        if (Input.GetKey(KeyCode.D)) horizontal = 1f;

        // Move the player based on input
        Vector3 movement = new Vector3(horizontal, vertical, 0f).normalized;
        transform.position += movement * speed * Time.deltaTime;
    }
}
