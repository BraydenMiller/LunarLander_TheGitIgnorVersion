using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //Hour health.
    public static int health;

    private void Start()
    {
        //Sets our health to 100.
        health = 100;
    }
    private void Update()
    {
        //Checks to make sure our health can never go below zero.
        if (health < 0)
        {
            health = 0;
        }
    }
}
