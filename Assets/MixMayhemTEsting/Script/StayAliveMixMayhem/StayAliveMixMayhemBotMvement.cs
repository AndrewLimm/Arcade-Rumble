using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayAliveMixMayhemBotMvement : MonoBehaviour
{
    public float speed = 3f; // Speed of the bot's movement
    public float leftLimit = -5f; // Left boundary for movement
    public float rightLimit = 5f; // Right boundary for movement

    private bool movingRight = true; // Direction of bot movement

    void Update()
    {
        MoveBot();
    }

    void MoveBot()
    {
        // Move the bot left or right based on the direction
        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            if (transform.position.x >= rightLimit)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            if (transform.position.x <= leftLimit)
            {
                movingRight = true;
            }
        }
    }
}
