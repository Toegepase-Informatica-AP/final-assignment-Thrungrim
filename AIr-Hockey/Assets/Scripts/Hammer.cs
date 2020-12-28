using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using UnityEngine;

public class Hammer : Agent
{
    private Environment environment;
    public float force = 250f;
    private Rigidbody rb = null;
    //public Transform orig = null;
    private float dirX = 0f;
    private float dirZ = 0f;
    public int goalAmount = 0;
    public bool matchWon = false;

    public override void Initialize()
    {
        rb = GetComponent<Rigidbody>();
        environment = GetComponentInParent<Environment>();
    }

    void FixedUpdate()
    {
        if (environment.rightSide)
        {
            AddReward(-0.0001f);
        }
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        dirX = 0f;
        dirZ = 0f;

        if (vectorAction[1] != 0f)
        {
            if (vectorAction[1] == 1f)
            {
                dirZ = force * Time.deltaTime;
            }
            else if (vectorAction[1] == 2f)
            {
                dirZ = force * Time.deltaTime;
                dirX = force * Time.deltaTime;
            }
            else if (vectorAction[1] == 3f)
            {
                dirX = force * Time.deltaTime;
            }
            else if (vectorAction[1] == 4f)
            {
                dirZ = -(force * Time.deltaTime);
                dirX = force * Time.deltaTime;
            }
            else if (vectorAction[1] == 5f)
            {
                dirZ = -(force * Time.deltaTime);
            }
            else if (vectorAction[1] == 6f)
            {
                dirZ = -(force * Time.deltaTime);
                dirX = -(force * Time.deltaTime);
            }
            else if (vectorAction[1] == 7f)
            {
                dirX = -(force * Time.deltaTime);
            }
            else if (vectorAction[1] == 8f)
            {
                dirZ = force * Time.deltaTime;
                dirX = -(force * Time.deltaTime);
            }
        }

        rb.velocity = new Vector3(dirX, 0, dirZ);
    }

    public override void OnEpisodeBegin()
    {
        goalAmount = 0;
        matchWon = false;
        environment.ClearEnvironment(true);
    }
    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[1] = 0f;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                actionsOut[1] = 8f;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                actionsOut[1] = 2f;
            }
            else
            {
                actionsOut[1] = 1f;
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                actionsOut[1] = 6f;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                actionsOut[1] = 4f;
            }
            else
            {
                actionsOut[1] = 5f;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            actionsOut[1] = 7f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            actionsOut[1] = 3f;
        }
    }
    private void ResetPlayer()
    {
        //transform.position = new Vector3(orig.position.x, orig.position.y, orig.position.z);
    }

    public void GetPoint()
    {
        AddReward(1f);
    }
    public void EndEpisodeHockey()
    {
        EndEpisode();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Puck") == true)
        {
            AddReward(0.1f);
        }
        if (collision.transform.CompareTag("Border") == true)
        {
            AddReward(-0.01f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("wallreward") == true)
        //{
        //    AddReward(0.1f);
        //}
    }
}
