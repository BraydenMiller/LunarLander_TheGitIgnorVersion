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
    public GameObject landingObject;
    public GameObject engineObject;
    public GameObject hurtObject;

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
            if (speed >= 25 && isGrounded == true)
            {
                Health.health -= Mathf.RoundToInt(speed);
                ScoreSystem.score -= 15;
                Hurt();
            }
            else
            {
                ScoreSystem.score -= 15;
                TurnOffHurt();
                Landing();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Sets our speed.
        speed = myRigidBody.velocity.magnitude;

        //Handles verticle movement using thrust & gravity.
        if (Input.GetButton("Upwards"))
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

    //Turns our hurt object on.
    void Hurt()
    {
        hurtObject.SetActive(true);
    }

    //Turns our landing object on.
    void Landing()
    {
        landingObject.SetActive(true);
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

    //Turns our hurt object off.
    void TurnOffHurt()
    {
        hurtObject.SetActive(false);
    }
}
