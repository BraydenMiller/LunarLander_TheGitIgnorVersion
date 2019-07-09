using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingThrusters : MonoBehaviour
{
    public float thrust;
    public float gravity;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        UpwardsThrusters();
        DirectionalThrusters();
        MovementThrusters();
        DownwardsThrusters();
    }

    void UpwardsThrusters() //(Z = BRT), (X = FLT), (C = BLT), (V = FRT)
    {
        if (Input.GetKey(KeyCode.Z))
        {
            rb.AddRelativeForce(transform.up * thrust);
            transform.Rotate(Vector3.right * 0.3f);
            transform.Rotate(Vector3.forward * 0.15f);
        }
        if (Input.GetKey(KeyCode.X))
        {
            rb.AddRelativeForce(transform.up * thrust);
            transform.Rotate(Vector3.left * 0.3f);
            transform.Rotate(Vector3.back * 0.15f);
        }
        if (Input.GetKey(KeyCode.C))
        {
            rb.AddRelativeForce(transform.up * thrust);
            transform.Rotate(Vector3.left * 0.3f);
            transform.Rotate(Vector3.forward * 0.15f);
        }
        if (Input.GetKey(KeyCode.V))
        {
            rb.AddRelativeForce(transform.up * thrust);
            transform.Rotate(Vector3.right * 0.3f);
            transform.Rotate(Vector3.back * 0.15f);
        }
    }

    void DownwardsThrusters() //(T = BRT), (Y = FLT), (U = BLT), (I = FRT)
    {
        if (Input.GetKey(KeyCode.T))
        {
            rb.AddRelativeForce(-transform.up * thrust);
            transform.Rotate(Vector3.left * 0.15f);
            transform.Rotate(Vector3.back * 0.15f);
        }
        if (Input.GetKey(KeyCode.Y))
        {
            rb.AddRelativeForce(-transform.up * thrust);
            transform.Rotate(Vector3.right * 0.15f);
            transform.Rotate(Vector3.forward * 0.15f);
        }
        if (Input.GetKey(KeyCode.U))
        {
            rb.AddRelativeForce(-transform.up * thrust);
            transform.Rotate(Vector3.left * 0.15f);
            transform.Rotate(Vector3.forward * 0.15f);
        }
        if (Input.GetKey(KeyCode.I))
        {
            rb.AddRelativeForce(-transform.up * thrust);
            transform.Rotate(Vector3.right * 0.15f);
            transform.Rotate(Vector3.back * 0.15f);
        }
    }

    void DirectionalThrusters() //(A = BRT), (S = FLT), (D = BLT), (F = FRT)
    {
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.F))
        {
            rb.AddForce(transform.right * thrust);
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            rb.AddForce(-transform.right * thrust);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * 0.3f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.up * 0.3f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.down * 0.3f);
        }
        if (Input.GetKey(KeyCode.F))
        {
            transform.Rotate(Vector3.down * 0.3f);
        }
    }

    void MovementThrusters() //(Q = BRT), (W = FLT), (E = BLT), (R = FRT)
    {
        if (Input.GetKey(KeyCode.Q))
        {
            rb.AddForce(transform.forward * thrust);
            transform.Rotate(Vector3.up * 0.15f);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(-transform.forward * thrust);
            transform.Rotate(Vector3.up * 0.15f);
        }
        if (Input.GetKey(KeyCode.E))
        {
            rb.AddForce(transform.forward * thrust);
            transform.Rotate(Vector3.down * 0.15f);
        }
        if (Input.GetKey(KeyCode.R))
        {
            rb.AddForce(-transform.forward * thrust);
            transform.Rotate(Vector3.down * 0.15f);
        }
    }
}
