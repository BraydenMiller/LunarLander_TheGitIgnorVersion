using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax, zMin, zMax;
}
public class PlayerScript : MonoBehaviour
{
    public Boundary boundary;

    //The verticle thrust & the side thrust.
    public float thrust;
    public float sideThrusters;
    public float deadZone;
    public float hurtZone;
    public float gravity;
    public bool isGrounded;
    float ourTransform;

    public float speed;
    public GameObject myGameObject;
    public GameObject landingObject;
    public GameObject engineObject;
    public GameObject hurtObject;

    //A reference to the game controller script.
    GameController gameController;

    //The player's rigidbody.
    public Rigidbody myRigidBody;

    // Start is called before the first frame update
    //Gets our player's rigidbody component.
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        isGrounded = false;
        //Gets our game controller script.
        gameController = GetComponent<GameController>();

        //Locks our cursor.
        Cursor.lockState = CursorLockMode.Locked;
        ourTransform = transform.rotation.x;
    }

    void OnCollisionEnter(Collision collision)
    {
        //Handles how we interact with the ground or any of the pads at a certain speed threshold.
        if (collision.collider.tag == "Ground")
        {
            isGrounded = true;
            if (speed >= hurtZone && isGrounded == true)
            {
                Health.health -= Mathf.RoundToInt(speed);
                ScoreSystem.score -= 15;
                Hurt();
                Invoke("TurnOffHurt", 0.4f);
            }
            else
            {
                ScoreSystem.score -= 15;
                Landing();
                Invoke("TurnOffLanding", 0.4f);
            }
        }

        if (collision.collider.tag == "LandingZone" || collision.collider.tag == "StartingPad")
        {
            isGrounded = true;
            if (speed >= hurtZone && isGrounded == true)
            {
                Health.health -= Mathf.RoundToInt(speed);
                ScoreSystem.score -= 15;
                Hurt();
                Invoke("TurnOffHurt", 0.4f);
            }
        }

        //If it collides with the player.
        if (collision.gameObject.tag == "InactivePad")
        {
            Debug.Log("Collision");
            /*Our win conditon - wins the game if we have enough points and the inactive pad has been set to true.
             *Then loads the main menu. Else shows an error message.
            */
            if (ScoreSystem.score >= 100)
            {
                gameController.gameStateText.text = "you win";
                Invoke("LoadTitle", 3f);
            }
        }

        if(collision.gameObject.tag == "StartingPad")
        {
            gameController.gameStateText.text = "get all of the pads and then return here!";
            Invoke("ClearString", 2f);
        }
    }

    private void FixedUpdate()
    {
        myRigidBody.position = new Vector3
        (
            Mathf.Clamp(myRigidBody.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(myRigidBody.position.y, boundary.yMin, boundary.yMax),
            Mathf.Clamp(myRigidBody.position.z, boundary.zMin, boundary.zMax));
    }
    // Update is called once per frame
    void Update()
    {

        if (transform.rotation.x <= 0)
        {
            ourTransform = 0;
        }

        //Sets our speed.
        speed = myRigidBody.velocity.magnitude;

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

    //Clears a text string.
    void ClearString()
    {
        gameController.gameStateText.text = "";
    }

    //Loads the title.
    void LoadTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
