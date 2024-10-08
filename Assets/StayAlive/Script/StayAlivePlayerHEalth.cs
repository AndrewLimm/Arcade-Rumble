using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayAlivePlayerHEalth : MonoBehaviour
{
    public int maxHealth = 100;  // Maximum health of the player
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;  // Initialize player's health to maximum
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;  // Reduce health by the damage amount

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log(gameObject.tag + " is dead!");  // Player is dead
            // You can add logic here to handle player death
        }
        else
        {
            Debug.Log(gameObject.tag + " has " + currentHealth + " health left.");
        }
    }
}
