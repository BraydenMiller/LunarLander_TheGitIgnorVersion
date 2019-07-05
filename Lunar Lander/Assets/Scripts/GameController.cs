using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //Our UI texts.
    public Text scoreText;
    public Text heightText;
    public Text velocityText;
    public Text hullText;
    public Text gameStateText;
    //Our player object.
    public GameObject myGameObject;

    // Update is called once per frame
    void Update()
    {

        //Our death trigger - loads the main scene if we die.
        if (Health.health <= 0)
        {
            gameStateText.text = "you lose";
            Invoke("LoadTitle", 3f);
        }

            //Sets our scoreUI.
            scoreText.text = ScoreSystem.score.ToString();

            //Sets our HeightUI to the player height.
            heightText.text = myGameObject.transform.position.y.ToString("f0") + "M";

            //Sets our VelocityUI to the velocity of the player.
            velocityText.text = myGameObject.GetComponentInChildren<Rigidbody>().velocity.magnitude.ToString("f0") + "Kms";

            //Sets our HullUI.
            hullText.text = Health.health.ToString() + "%";

    }

    //Loads the title.
    void LoadTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
