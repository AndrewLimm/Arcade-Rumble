using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayAliveBulletMovementUp : MonoBehaviour
{
    public float speed = 5f;  // Speed of the bullet
    public float lifetime = 3f;  // Lifetime of the bullet before being destroyed
    public int damage = 10;

    void Start()
    {
        // Destroy the bullet after the specified lifetime
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Move the bullet downward
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object has the tag "Player1" or "Player2"
        if (collision.CompareTag("Player1") || collision.CompareTag("Player2"))
        {
            // Attempt to access the player's health component and reduce health
            StayAlivePlayerHEalth playerHealth = collision.GetComponent<StayAlivePlayerHEalth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage); // Correctly reduce the player's health by the damage amount
            }

            // Destroy the bullet upon collision with the player
            Destroy(gameObject);
        }
    }
}
