using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AddTime : MonoBehaviour
{
    public float timeToAdd = 10f; // Amount of time to add when collected
    public float rotationSpeed = 1f;
    public float disableDuration = 5f; // Time in seconds the pickup remains disabled
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Find the Timer script in the scene
            Timer timer = FindObjectOfType<Timer>();
            if (timer != null)
            {
                timer.AddTime(timeToAdd);
            }
            // Disable the time pickup object
            gameObject.SetActive(false);
            // Re-enable the pickup after the specified duration using Invoke
            Invoke("ReactivatePickup", disableDuration);
        }
    }
    private void ReactivatePickup()
    {
        // Re-enable the pickup object
        gameObject.SetActive(true);
    }
}