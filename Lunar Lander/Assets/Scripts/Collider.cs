using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{
    public int multiplier;

    public GameObject parentGameObject;
    // Start is called before the first frame update

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log(collision);
            gameObject.GetComponent<Material>().color = Color.red;
            ScoreSystem.score += 10 * multiplier;
            gameObject.GetComponent<ColliderScript>().enabled = false;
        }
    }
}
