using System.Collections;
using UnityEngine;

public class PowerupJump : MonoBehaviour
{
    public GameObject Character;
    public float newGravityScale = 1f;
    public float powerupDuration = 5f;
    public float rotationSpeed = 1f;

    private bool isPowerUpActive = false;

    private SpriteRenderer spriteRenderer; // To control visibility
    private new Collider2D collider2D; // To disable collisions
    

    private void Start()
    {
        if (Character == null)
        {
            Character = GameObject.FindWithTag("Player");
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<Collider2D>();

        if (spriteRenderer == null || collider2D == null)
        {
            Debug.LogError("PowerupJump: Missing SpriteRenderer or Collider2D component!");
        }
    }

    private void Update()
    {
        // Rotate the power-up if it's visible (not collected)
        if (spriteRenderer.enabled)
        {
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = collision2D.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null && !isPowerUpActive)
            {
                StartCoroutine(HandlePowerup(rb));
            }
        }
    }

    private IEnumerator HandlePowerup(Rigidbody2D rb)
    {
        if (isPowerUpActive) yield break; // Prevent multiple activations
        isPowerUpActive = true;

        // Store original gravity and change it
        float originalGravityScale = rb.gravityScale;
        rb.gravityScale = newGravityScale;

        // Hide the power-up
        spriteRenderer.enabled = false;
        collider2D.enabled = false;

        Debug.Log("Power-up effect started: Gravity scale changed to " + newGravityScale);
        yield return new WaitForSecondsRealtime(powerupDuration);

        // Reset gravity scale
        if (rb != null)
        {
            rb.gravityScale = originalGravityScale;
            Debug.Log("Power-up effect ended: Gravity scale reset to " + originalGravityScale);
        }

        // Re-enable the power-up
        spriteRenderer.enabled = true;
        collider2D.enabled = true;

        isPowerUpActive = false;
    }
}
