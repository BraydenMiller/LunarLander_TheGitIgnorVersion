using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    //The player's rigidbody.
    public Rigidbody myRigidBody;

    public float thrust;
    public float sideThrusters;
    public float deadZone;
    public float gravity;
    public bool isGrounded;

    public GameObject engineObject;
    public GameObject landingObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Handles verticle movement using thrust & gravity with controller.
        if (Input.GetAxis("Upwards") > deadZone)
        {
            myRigidBody.AddForce(transform.up * thrust);
            isGrounded = false;
            TurnOffLanding();
            ShipEngines();
        }
        //Handles verticle movement using thrust & gravity with keyboard.
        else if (Input.GetKey(KeyCode.Space))
        {
            myRigidBody.AddForce(transform.up * thrust);
            isGrounded = false;
            TurnOffLanding();
            ShipEngines();
        }
        else
        {
            myRigidBody.AddForce(transform.up * gravity);
            TurnOffEngines();
        }

        //Handles moving left, right, forward and backwards using our sideThrust value.
        //XboxController
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

        //PC Keyboard      
        if (Input.GetKey(KeyCode.D) && isGrounded == false)
        {
            myRigidBody.AddForce(transform.right * thrust * sideThrusters);
        }

        if (Input.GetKey(KeyCode.A) && isGrounded == false)
        {
            myRigidBody.AddForce(transform.right * -thrust * sideThrusters);
        }

        if (Input.GetKey(KeyCode.S) && isGrounded == false)
        {
            myRigidBody.AddForce(transform.forward * -thrust * sideThrusters);
        }

        if (Input.GetKey(KeyCode.W) && isGrounded == false)
        {
            myRigidBody.AddForce(transform.forward * thrust * sideThrusters);
        }
    }

    //Turns our engine  object on.
    void ShipEngines()
    {
        engineObject.SetActive(true);
    }

    //Turns our engine object off.
    void TurnOffEngines()
    {
        engineObject.SetActive(false);
    }

    //Turns our landing object off.
    void TurnOffLanding()
    {
        landingObject.SetActive(false);
    }
}
