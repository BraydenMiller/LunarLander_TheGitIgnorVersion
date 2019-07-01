using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{
    public int multiplier;
    public GameObject inactivePad;
    public GameObject otherPad;
    public GameObject parentGameObject;
    // Start is called before the first frame update

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            otherPad.SetActive(false);
            inactivePad.SetActive(true);
            ScoreSystem.score += 10 * multiplier;
        }
    }
}
