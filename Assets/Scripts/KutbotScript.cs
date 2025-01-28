using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KutbotScript : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce = 7f; // Sprungkraft anpassen
    private bool isGrounded = false;
    public GameObject cam;
    public GameObject boxPrefab;
    public float destructionDelay = 30f;
    public GameObject holdposition;


    void Update()
    {
        // Horizontal Movement
        float horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y); //Vertical movement

        // Jump
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Horizonal movement
            isGrounded = false; //player is mid air
        }

        //Spawn Box
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            GameObject spawnedBox = Instantiate(boxPrefab, holdposition.transform.position, Quaternion.identity);

            Destroy(spawnedBox, destructionDelay);
        }

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
       
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Box"))
        {
            isGrounded = true; //player on the floor
        }

        if (collision.gameObject.CompareTag("goal"))
        {
            FindObjectOfType<Timer>().SaveTime();
            SceneManager.LoadScene("leaderborad");
        }
    }



}
