using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOverPlayer1Health : MonoBehaviour
{
    public int maxHealth = 2; // Maximum health for the player
    public int currentHealth; // Current health of the player

    private void Start()
    {
        currentHealth = maxHealth; // Set initial health to max health
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player collides with an obstacle
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            TakeDamage(1); // Decrease health by 1 when hitting an obstacle
        }
    }

    private void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Reduce the player's health by the damage amount
        Debug.Log("Player's health is now: " + currentHealth);

        if (currentHealth <= 0)
        {
            HandlePlayerDeath(); // Handle the player's death if health is zero or less
        }
    }

    private void HandlePlayerDeath()
    {
        Debug.Log("Player is defeated!");
        // Add logic for when the player is defeated (e.g., disable player movement, show Game Over screen, etc.)
        gameObject.SetActive(false); // Example: Disable the player game object
    }

    public int GetCurrentHealth()
    {
        return currentHealth; // Return the current health value of the player
    }
}
