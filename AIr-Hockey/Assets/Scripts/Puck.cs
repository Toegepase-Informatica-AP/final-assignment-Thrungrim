using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour
{
    private Environment environment;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        environment = GetComponentInParent<Environment>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Field"))
        {
            rb.constraints = RigidbodyConstraints.FreezePositionY;
        }

        if (collision.gameObject.CompareTag("HammerPlayer") || collision.gameObject.CompareTag("HammerOpponent"))
        {
            rb.velocity = new Vector3(rb.velocity.x * 3, 0, rb.velocity.z * 3);
        }

        if (collision.gameObject.CompareTag("Border"))
        {
            var orthogonalVector = collision.contacts[0].point - transform.position;
            var collisionAngle = Vector3.Angle(orthogonalVector, rb.velocity);
            transform.rotation *= Quaternion.Euler(0, collisionAngle, 0);
            rb.velocity = new Vector3(rb.velocity.x * 2, 0, rb.velocity.z * 2);
            //rb.velocity = Vector3.Reflect(collision.relativeVelocity * 2, collision.contacts[0].normal);
            //rb.velocity = new Vector3(25, 0, 25);
        }
        if (collision.gameObject.CompareTag("GoalPlayer"))
        {
            environment.AddPointsOpponent();
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            environment.ClearEnvironment(false);
        }
        if (collision.gameObject.CompareTag("GoalOpponent"))
        {
            environment.AddPointsPlayer();
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            environment.ClearEnvironment(true);
        }
    }
}
