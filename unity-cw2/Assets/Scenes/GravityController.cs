using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float directionChangeInterval = 6f;
    public float increasedGravityForce = -20f; // Force to simulate increased gravity

    private float directionChangeTimer;
    private Vector3 randomDirection;
    private Rigidbody rb;
    private bool isGravityEnabled = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found on the object");
            return;
        }

        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        SetRandomDirection();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            isGravityEnabled = !isGravityEnabled;
            rb.useGravity = isGravityEnabled;
            rb.velocity = Vector3.zero; // Reset velocity when toggling gravity
        }

        if (!isGravityEnabled)
        {
            rb.velocity = randomDirection * moveSpeed;
            directionChangeTimer += Time.deltaTime;
            if (directionChangeTimer >= directionChangeInterval)
            {
                directionChangeTimer = 0;
                SetRandomDirection();
            }
        }
        else
        {
            // Apply an increased gravity force
            rb.AddForce(new Vector3(0, increasedGravityForce, 0), ForceMode.Acceleration);
        }
    }

    private void SetRandomDirection()
    {
        randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isGravityEnabled)
        {
            randomDirection = Vector3.Reflect(randomDirection, collision.contacts[0].normal).normalized;
        }
    }
}
