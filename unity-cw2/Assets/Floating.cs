using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBounce : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;
    private float directionChangeInterval = 2f; // Time in seconds between random direction changes
    private float timeSinceLastChange = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        rb.useGravity = false; // Disable gravity for floating effect
        RandomizeDirection();
    }

    void Update()
    {
        timeSinceLastChange += Time.deltaTime;
        if (timeSinceLastChange >= directionChangeInterval)
        {
            RandomizeDirection();
            timeSinceLastChange = 0f;
        }
    }

    void RandomizeDirection()
    {
        Vector3 direction = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)
        ).normalized;
        rb.velocity = direction * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 reflectedVelocity = Vector3.Reflect(rb.velocity, collision.contacts[0].normal);
        rb.velocity = reflectedVelocity.normalized * speed;
        RandomizeDirection(); // Randomize direction after collision
    }
}
