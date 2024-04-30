using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupTimer : MonoBehaviour
{
     public float duration = 10f; // Duration of the power-up in seconds

    private float timer; // Timer to track the duration

    void Start()
    {
        timer = duration; // Initialize the timer
    }

    void Update()
    {
        // Update the timer
        timer -= Time.deltaTime;

        // Check if the timer has reached zero
        if (timer <= 0f)
        {
            // Disable the power-up GameObject
            gameObject.SetActive(false);
        }
    }

    // Method to activate the power-up (e.g., when the player picks it up)
    public void Activate()
    {
        // Reset the timer when the power-up is activated
        timer = duration;
    }
}
