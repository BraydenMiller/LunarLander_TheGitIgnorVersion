using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary2
{
    public float xMin, xMax, yMin, yMax, zMin, zMax;
}

public class MultiplayerPlayerHandler : MonoBehaviour
{

    //Our boundary constraints
    public Boundary2 boundary;

    //The player's rigidbody.
    public Rigidbody myRigidBody;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        myRigidBody.position = new Vector3
        (
            Mathf.Clamp(myRigidBody.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(myRigidBody.position.y, boundary.yMin, boundary.yMax),
            Mathf.Clamp(myRigidBody.position.z, boundary.zMin, boundary.zMax));
    }
}
