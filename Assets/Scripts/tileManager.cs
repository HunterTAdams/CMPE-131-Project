using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileManager : MonoBehaviour
{
    public GameObject occupant;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //returns the current occupant of the tile
    public GameObject getOccupant()
    {
        return occupant;
    }

    //removes this tile's memory of the occupant. called when something leaves the tile.
    public void clearOccupant()
    {
        occupant = null;
    }

    //sets the tile's occupant. used when something moves to the tile.
    public void setOccupant(GameObject occ)
    {
        occupant = occ;
    }
}
