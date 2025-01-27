using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KutbotScript : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce = 7f; // Sprungkraft anpassen
    private bool isGrounded = false;
    public GameObject cam;
    public GameObject boxPrefab;



    // Update is called once per frame
    void Update()
    {
        // Horizontal Movement
        float horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y); // Setzt nur die X-Geschwindigkeit

        // Sprung-Logik
        if (Input.GetKey(KeyCode.W) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Setzt nur die Y-Geschwindigkeit f�r den Sprung
            isGrounded = false; // Setzt den Grounded-Status auf false, wenn der Spieler springt
        }

        //Spawn Box
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            boxPrefab = Instantiate(boxPrefab, transform.position, Quaternion.identity);
        }

        // Kamera folgt dem Spieler
        //cam.transform.position = new Vector3(rb.position.x, rb.position.y+ 1, cam.transform.position.z);

        if (horizontal > 0.01f)
        {
            transform.localScale = Vector3.one;
        }else if (horizontal < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Pr�ft, ob der Spieler den Boden ber�hrt
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Box"))
        {
            isGrounded = true; // Spieler ist auf dem Boden
        }
    }



}
