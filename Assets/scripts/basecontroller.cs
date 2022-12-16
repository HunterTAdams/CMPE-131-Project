using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class basecontroller : MonoBehaviour
{
    float time2turn;
    public float timeonturn;
    public int initposx;
    public int initposy;
    public tileScript currentTile;
    public float inittime;
    public Text timedisplay;
    public GameObject[] hovermoveshow = new GameObject[1];
    public AudioSource movesound;
    public bool invulnerable;//walls
    public bool ghost; //triggers
    public float vision; //how close the player needs to be to a piece for it to move
    // all pieces will be placed inactive, something will wake them, and when they do, this is called.
    public virtual void Awake()
    {
        time2turn = inittime;
        tileaccess.tileDict[new Vector2Int(initposx, initposy)].moveTo(this);
    }

    // Update is called once per frame. decrements time2turn and calls turn when it hits 0.
    public virtual void Update()
    {
        if (!tileaccess.isPlayerTurn)
        {
            time2turn += -Time.deltaTime;
            timedisplay.text = Mathf.Ceil(time2turn).ToString("F0");
            if (time2turn <= 0)
            {
                Turn();
                 //leave unreferenced on player piece
                time2turn = timeonturn;
            }
        }
    }

    //overwritten by every piece. Has the piece AI and makes it move, globally stops updating time on players turn and waits for input.
    public virtual void Turn()
    {

    }

    //how each piece dies. For most pieces, this is remove themselves from the board and add to the corrosponding dead thing counter on tileaccess
    public virtual void death(basecontroller attacker)
    {

    }

    //a feature each piece will eventually need to implement individually is onMouseEnter and onMouseExit to display the tiles in which they can move when they get hovered over. we will implement this later, for now just do the AI
    public virtual void OnMouseEnter()
    {

    }
    public virtual void OnMouseExit()
    {

    }
}
