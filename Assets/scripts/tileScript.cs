using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileScript : MonoBehaviour
{
    public basecontroller occupant;
    public Vector2Int position;

    //returns false if this tile has an occupant/occupant isnt null, otherwise sets the occupant of mover's current tile to null, moves mover physically to the location of the tile, sets occupant to mover, sets the position on the mover to this position.
    public bool moveTo(basecontroller mover)
    {
        if(occupant == null)
        {
            if(mover.currentTile != null)
            {
                mover.currentTile.occupant = null;
            }
            mover.transform.position = this.transform.position - .25f*Vector3.up;
            mover.currentTile = this;
            occupant = mover;
            return true;
        }
        if(occupant != mover)
        {
            occupant.death();
        }
        return false;
    }

    //
    public basecontroller getOccupant()
    {
        return occupant;
    }

}
