using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float force = 10f;
    public Rigidbody rb; 
    private float dirX;
    private float dirZ;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        dirX = Input.GetAxis("Horizontal") * force;
        dirZ = Input.GetAxis("Vertical") * force;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(dirX, rb.velocity.y, dirZ);
    }
}
