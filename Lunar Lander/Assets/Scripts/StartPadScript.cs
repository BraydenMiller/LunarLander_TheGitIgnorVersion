using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPadScript : MonoBehaviour
{
    //A reference to our pad.
    public GameObject myPad;
    //A reference to our inactive pad.
    public GameObject inactivePad;

    void Update()
    {
        //Checks to see if our padScore is equal to or greater than 7.
        if (ScoreSystem.padScore >= 7)
        {
            SetPads();
        }
    }

    //Sets our pad to inactive and our win condition pad to true.
    void SetPads()
    {
        myPad.SetActive(false);
        inactivePad.SetActive(true);
    }
}
