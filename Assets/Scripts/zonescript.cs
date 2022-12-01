using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zonescript : MonoBehaviour
{
    public GameObject[] pieces;
    public GameObject[] wall;
    public basecontroller king;
    public Camera main;
    public GameObject hud;
    public bool deadonce = false;
    


    public void Awake()
    {
        tileaccess.currentzone = this;
        king.timeonturn = 1f;

        //awoken by the trigger death. destroys the previous trigger, places the next wall. spawns all of pieces. briefly moves the camera to see the next zone. set king timeonturn to 1
    }


    public void checkdead()
    {
        Debug.Log("checkdead");
        if (!deadonce)
        {
            
            bool alldead = true;
            foreach (GameObject i in pieces)
            {
                if (i != null)
                {
                    alldead = false;
                }
            }
            Debug.Log(alldead);
            if (alldead)
            {
                
                foreach (GameObject i in wall)
                {
                    Destroy(i);
                }
                king.timeonturn = .1f;
                deadonce = true;
            }
            
        }
        //if true, kill the wall and place the trigger, play the proceed message, set king time to 0

    }
}
