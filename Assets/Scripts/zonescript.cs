using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zonescript : MonoBehaviour
{
    public GameObject[] pieces;
    public GameObject[] wall;
    public basecontroller king;
    public Camera main;
    public GameObject cleartext;
    public bool deadonce = false;
    public AudioSource music;
    public Vector2Int checkposition;



    public void Awake()
    {
        if (tileaccess.currentzone != null)
        {
            StartCoroutine(FadeAudioSource.StartFade(tileaccess.currentzone.music, 4, 0));
        }
        music.Play();
        StartCoroutine(FadeAudioSource.StartFade(music, 4, 1));
        cleartext.SetActive(false);
        tileaccess.currentzone = this;
        king.timeonturn = 1f;
        king.initposx = checkposition.x;
        king.initposy = checkposition.y;

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
            if (alldead)
            {
                
                foreach (GameObject i in wall)
                {
                    Destroy(i);
                }
                king.timeonturn = .1f;
                cleartext.SetActive(true);
                deadonce = true;
            }
            
        }
        //if true, kill the wall and place the trigger, play the proceed message, set king time to 0

    }
}
