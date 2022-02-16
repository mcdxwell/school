using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCue : MonoBehaviour
{

    public GameObject Cue2;
    public GameObject CueBall;

    void moveToCueBall()
    {
        // Set Cue position to the position of the CueBall
        Cue2.transform.position = CueBall.transform.position;
    }

    public void whenButtonClicked()
    {

        // if cue is not active in hierachy
        if(Cue2.activeInHierarchy == false)
        {
            // make cue active
            Cue2.SetActive(true);

            // move cue to cueball
            moveToCueBall();
            Debug.Log("Show Cue");
        }
    }
}
