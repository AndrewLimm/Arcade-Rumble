using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayAlivePlayer2Controller : MonoBehaviour
{
    public float speed = 5f; // Adjust the movement speed

    void Update()
    {
        // Player 2 movement (IJKL)
        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(KeyCode.I)) vertical = 1f;
        if (Input.GetKey(KeyCode.K)) vertical = -1f;
        if (Input.GetKey(KeyCode.J)) horizontal = -1f;
        if (Input.GetKey(KeyCode.L)) horizontal = 1f;

        // Move the player based on input
        Vector3 movement = new Vector3(horizontal, vertical, 0f).normalized;
        transform.position += movement * speed * Time.deltaTime;
    }
}
