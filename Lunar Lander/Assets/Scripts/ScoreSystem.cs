using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    //Our score.
    public static int score;
    //Our pad scroe which will be used to keep track of how many pads we have collided with.
    public static int padScore;

    //Sets our scores to 0 when the game is started.
    private void Start()
    {
        score = 0;
        padScore = 0;
    }

    private void Update()
    {
        //Checks to make sure our score can never go below zero.
        if (score < 0)
        {
            score = 0;
        }
    }
}
