using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckGame : MonoBehaviour
{
    private Game game;
    private Rigidbody rb;
    private float maxSpeed = 25f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        game = GetComponentInParent<Game>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Field"))
        {
            rb.constraints = RigidbodyConstraints.FreezePositionY;
        }

        if (collision.gameObject.CompareTag("HammerPlayer") || collision.gameObject.CompareTag("HammerOpponent"))
        {
            rb.velocity = new Vector3(rb.velocity.x * 5, 0, rb.velocity.z * 5);
        }

        if (collision.gameObject.CompareTag("Border"))
        {
            var orthogonalVector = collision.contacts[0].point - transform.position;
            var collisionAngle = Vector3.Angle(orthogonalVector, rb.velocity);
            transform.rotation *= Quaternion.Euler(0, collisionAngle, 0);
            rb.velocity = new Vector3(rb.velocity.x * 2, 0, rb.velocity.z * 2);
        }
        if (collision.gameObject.CompareTag("GoalPlayer"))
        {
            game.AddPointsOpponent();
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            game.ResetGame(false);
        }
        if (collision.gameObject.CompareTag("GoalOpponent"))
        {
            game.AddPointsPlayer();
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            game.ResetGame(true);
        }
    }
}
