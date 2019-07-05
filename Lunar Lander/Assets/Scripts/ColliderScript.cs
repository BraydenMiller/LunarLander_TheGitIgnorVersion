using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{
    //A score multiplier for use with the inner and outter pads.
    public int multiplier;

    public GameObject inactivePad;

    //The pad that the player does not land on.
    public GameObject otherPad;
    //The gameObject as a whole.
    public GameObject parentGameObject;

    //Handles how we collide with things.
    private void OnCollisionEnter(Collision collision)
    {
        /*If we collide with a player object; Destroy ourselves and set our other pad to inactive.
         *Sets our inactive pad to active.
         * Adds to our overall score and our pad score.
        */
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            otherPad.SetActive(false);
            inactivePad.SetActive(true);
            ScoreSystem.score += 10 * multiplier;
            ScoreSystem.padScore += 1;
        }
    }
}
