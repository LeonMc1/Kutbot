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
        Vector3 targetPosition = Character.position + offset;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
