using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //The verticle thrust & the side thrust.
    public float thrust;
    public float sideThrusters;
    public float deadZone;
    public float gravity;
    public bool isGrounded;
    float speed;
    public GameObject myGameObject;

    //The player's rigidbody.
    public Rigidbody myRigidBody;

    // Start is called before the first frame update
    //Gets our player's rigidbody component.
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        isGrounded = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = true;
            ScoreSystem.score -= 15;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (speed >= 25 && isGrounded == true)
        {
            Health.health -= Mathf.RoundToInt(speed);
        } 

        speed = myRigidBody.velocity.magnitude;

        Debug.Log(speed);

        //Handles verticle movement using thrust & gravity.
        if (Input.GetButton("Upwards"))
        {
            myRigidBody.AddForce(transform.up * thrust);
            isGrounded = false;
        }
        else
        {
            myRigidBody.AddForce(transform.up * gravity);
        }



        //Handles moving left, right, forward and backwards using our sideThrust value.
        if (Input.GetAxis("Forwards") < -deadZone && isGrounded == false)
        {
            myRigidBody.AddForce(transform.forward * thrust * sideThrusters);
        }

        if (Input.GetAxis("Backwards") > deadZone && isGrounded == false)
        {
            myRigidBody.AddForce(transform.forward * -thrust * sideThrusters);
        }

        if (Input.GetAxis("Left") < -deadZone && isGrounded == false)
        {
            myRigidBody.AddForce(transform.right * -thrust * sideThrusters);
        }

        if (Input.GetAxis("Right") > deadZone && isGrounded == false)
        {
            myRigidBody.AddForce(transform.right * thrust * sideThrusters);
        }
    }
}
