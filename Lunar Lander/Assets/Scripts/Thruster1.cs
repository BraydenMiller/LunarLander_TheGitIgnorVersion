using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster1 : MonoBehaviour
{
   //The verticle thrust & the side thrust.
    public float thrust;
    public float deadZone;


    //The player's rigidbody.
    public Rigidbody myRigidBody;

    // Start is called before the first frame update
    //Gets our player's rigidbody component.
    void Start()
    {
        myRigidBody = myRigidBody.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Handles verticle movement using thrust & gravity.
        if (Input.GetButton("Upwards1"))
        {
            myRigidBody.AddForce(transform.up * thrust);
        }
    }
}
