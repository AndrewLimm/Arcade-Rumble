using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayAliveMixMayhemPlayer1COntroller : MonoBehaviour
{
    public int maxHealth = 100;  // Maximum health of the player
    public int currentHealth;

    [SerializeField] StayAliveMixMayhemGameOverManager gameOverManager;

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
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Debug.Log(gameObject.tag + " is dead!");  // Player is dead

                // Panggil metode TriggerEnd di GameOverManager jika health pemain mencapai 0
                if (gameOverManager != null)
                {
                    gameOverManager.TriggerEnd();
                }
            }
            else
            {
                Debug.Log(gameObject.tag + " has " + currentHealth + " health left.");
            }
        }
    }
}
