using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingThrusters : MonoBehaviour
{
    public float thrust;
    public float gravity;
    public float deadZone;
    public float movementThrusters;
    public bool letPlay = true;

    public ParticleSystem downParticle1;
    public ParticleSystem downParticle2;
    public ParticleSystem downParticle3;
    public ParticleSystem downParticle4;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(-transform.up * gravity);
        P1TN();
        P2TN();
        P3TN();
        P4TN();
        DirectionalThrusters();
        UpwardsThrusters();
        MovementThrusters();
        DownwardsThrusters();
        ThrusterFrontLeft();
        ThrusterFrontRIght();
        ThrusterBackRight();
        ThrusterBackLeft();
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
        if (Input.GetAxis("P1S") < deadZone && Input.GetAxis("P3S") < deadZone)
        {
            rb.AddForce(transform.right * thrust * movementThrusters);
        }
        if (Input.GetAxis("P2S") > deadZone && Input.GetAxis("P4S") > deadZone)
        {
            rb.AddForce(-transform.right * thrust * movementThrusters);
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

    void P1TN()//BRT
    {
        if (Input.GetAxis("P1U") > deadZone)
        {
            IsPlaying();
            rb.AddForce(transform.up * thrust);
            transform.Rotate(Vector3.right * 0.2f);
            transform.Rotate(Vector3.forward * 0.15f);
        }
        if (Input.GetAxis("P1D") > deadZone)
        {
            IsPlaying();
            rb.AddRelativeForce(-transform.up * thrust);
            transform.Rotate(Vector3.left * 0.15f);
            transform.Rotate(Vector3.back * 0.15f);
        }
        if (Input.GetAxis("P1S") < deadZone)
        {
            IsPlaying();
            transform.Rotate(Vector3.up * 0.2f);
        }
        if (Input.GetAxis("P1M") > deadZone)
        {
            IsPlaying();
            rb.AddForce(transform.forward * thrust * movementThrusters);
            transform.Rotate(Vector3.up * 0.03f);
        }
        else
        {
            NoPlay();
        }
    }

    void P2TN()//FLT
    {
        if (Input.GetAxis("P2U") > deadZone)
        {
            IsPlaying();
            rb.AddForce(transform.up * thrust);
            transform.Rotate(Vector3.left * 0.2f);
            transform.Rotate(Vector3.back * 0.15f);
        }
        if (Input.GetAxis("P2D") > deadZone)
        {
            IsPlaying();
            rb.AddRelativeForce(-transform.up * thrust);
            transform.Rotate(Vector3.right * 0.15f);
            transform.Rotate(Vector3.forward * 0.15f);
        }
        if (Input.GetAxis("P2S") > deadZone)
        {
            IsPlaying();
            transform.Rotate(Vector3.up * 0.2f);
        }
        if (Input.GetAxis("P2M") < deadZone)
        {
            IsPlaying();
            rb.AddForce(-transform.forward * thrust * movementThrusters);
            transform.Rotate(Vector3.up * 0.03f);
        }
        else
        {
            NoPlay();
        }
    }

    void P3TN()//FRT
    {
        if (Input.GetAxis("P3U") > deadZone)
        {
            IsPlaying();
            rb.AddForce(transform.up * thrust);
            transform.Rotate(Vector3.left * 0.2f);
            transform.Rotate(Vector3.forward * 0.15f);
        }
        if (Input.GetAxis("P3D") > deadZone)
        {
            IsPlaying();
            rb.AddRelativeForce(-transform.up * thrust);
            transform.Rotate(Vector3.right * 0.15f);
            transform.Rotate(Vector3.back * 0.15f);
        }
        if (Input.GetAxis("P3S") < deadZone)
        {
            IsPlaying();
            transform.Rotate(Vector3.down * 0.2f);
        }
        if (Input.GetAxis("P3M") < deadZone)
        {
            IsPlaying();
            rb.AddForce(-transform.forward * thrust * movementThrusters);
            transform.Rotate(Vector3.down * 0.03f);
        }
        else
        {
            NoPlay();
        }
    }

    void P4TN()//BLT
    {
        if (Input.GetAxis("P4U") > deadZone)
        {
            IsPlaying();
            rb.AddForce(transform.up * thrust);
            transform.Rotate(Vector3.right * 0.2f);
            transform.Rotate(Vector3.back * 0.15f);
        }
        if (Input.GetAxis("P4D") > deadZone)
        {
            IsPlaying();
            rb.AddRelativeForce(-transform.up * thrust);
            transform.Rotate(Vector3.left * 0.15f);
            transform.Rotate(Vector3.forward * 0.15f);
        }
        if (Input.GetAxis("P4S") > deadZone)
        {
            IsPlaying();
            transform.Rotate(Vector3.down * 0.2f);
        }
        if (Input.GetAxis("P4M") > deadZone)
        {
            IsPlaying();
            rb.AddForce(transform.forward * thrust * movementThrusters);
            transform.Rotate(Vector3.down * 0.03f);
        }
        else
        {
            NoPlay();
        }
    }

    void ThrusterFrontLeft()
    {
        if (letPlay)
        {
            if (!downParticle1.isPlaying)
            {
                downParticle1.Play();
            }
        }
        else
        {
            if (downParticle1.isPlaying)
            {
                downParticle1.Stop();
            }
        }
    }

    void ThrusterFrontRIght()
    {
        if (letPlay)
        {
            if (!downParticle2.isPlaying)
            {
                downParticle2.Play();
            }
        }
        else
        {
            if (downParticle2.isPlaying)
            {
                downParticle2.Stop();
            }
        }
    }

    void ThrusterBackLeft()
    {
        if (letPlay)
        {
            if (!downParticle3.isPlaying)
            {
                downParticle3.Play();
            }
        }
        else
        {
            if (downParticle3.isPlaying)
            {
                downParticle3.Stop();
            }
        }
    }

    void ThrusterBackRight()
    {
        if (letPlay)
        {
            if (!downParticle4.isPlaying)
            {
                downParticle4.Play();
            }
        }
        else
        {
            if (downParticle4.isPlaying)
            {
                downParticle4.Stop();
            }
        }
    }

    void IsPlaying()
    {
        letPlay = true;
    }

    void NoPlay()
    {
        letPlay = false;
    }
}
