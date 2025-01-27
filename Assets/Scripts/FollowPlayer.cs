using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform Character;
    public float smoothTime = 0.3f;
    public Vector3 offset;

    private Vector3 velocity = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Cam();

    }
    void Cam()
    {
        // Preserve the current x and z coordinates of the camera
        Vector3 targetPosition = new Vector3(
            transform.position.x, // Keep the current x-coordinate
            Character.position.y + offset.y, // Follow the y-coordinate of the character
            transform.position.z  // Keep the current z-coordinate
        );

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
