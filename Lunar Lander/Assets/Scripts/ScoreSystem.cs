using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public static int score;

    private void Start()
    {
        score = 0;
    }

    private void Update()
    {
        if (score < 0)
        {
            score = 0;
        }
    }
}
