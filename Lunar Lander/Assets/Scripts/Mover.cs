using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mover : MonoBehaviour
{

    //The player's rigidbody.
    public Rigidbody myRigidBody;

    public float thrust;
    public float sideThrusters;
    public float deadZone;
    public float gravity;
    public bool isGrounded;
    public bool letPlay = true;
    public float turnRate;

    public GameObject engineObject;
    public ParticleSystem downParticle1;
    public ParticleSystem downParticle2;
    public ParticleSystem downParticle3;
    public ParticleSystem downParticle4;

    public GameObject landingObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(0.0f, -Input.GetAxis("Horizontal") * turnRate, 0.0f);

        //Handles verticle movement using thrust & gravity with controller.
        if (Input.GetAxis("Upwards") > deadZone)
        {
            letPlay = true;
            myRigidBody.AddForce(transform.up * thrust);
            isGrounded = false;
            TurnOffLanding();
            downParticle1.Play();
            ShipEngines();
        }
        //Handles verticle movement using thrust & gravity with keyboard.
        else if (Input.GetKey(KeyCode.Space))
        {
            myRigidBody.AddForce(transform.up * thrust);
            isGrounded = false;
            letPlay = true;
            TurnOffLanding();
            ShipEngines();
        }
        else
        {
            letPlay = false;
            myRigidBody.AddForce(transform.up * gravity);
            TurnOffEngines();
        }

        if (letPlay)
        {
            if (!downParticle1.isPlaying)
            {
                downParticle1.Play();
                downParticle2.Play();
                downParticle3.Play();
                downParticle4.Play();
            }
        }
        else
        {
            if (downParticle1.isPlaying)
            {
                downParticle1.Stop();
                downParticle2.Stop();
                downParticle3.Stop();
                downParticle4.Stop();
            }

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
