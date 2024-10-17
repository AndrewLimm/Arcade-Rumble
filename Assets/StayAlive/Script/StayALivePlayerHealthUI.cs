using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StayALivePlayerHealthUI : MonoBehaviour
{
    public Slider healthSlider; // Referensi ke Slider UI
    public StayAlivePlayerHEalth playerHealth; // Referensi ke script kesehatan pemain

    void Start()
    {
        // Set nilai maksimum pada Slider sesuai dengan maximum health pemain
        if (playerHealth != null && healthSlider != null)
        {
            healthSlider.maxValue = playerHealth.maxHealth;
            healthSlider.value = playerHealth.currentHealth;
        }
    }

    void Update()
    {
        // Update nilai Slider sesuai dengan current health pemain
        if (playerHealth != null && healthSlider != null)
        {
            healthSlider.value = playerHealth.currentHealth;
        }
    }
}
