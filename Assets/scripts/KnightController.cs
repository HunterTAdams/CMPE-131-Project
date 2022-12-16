using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : basecontroller//obnoxious zoning fuck that takes waiting for the right moment to take without energy.
{
    public Vector2Int[] movetiles = new Vector2Int[8];
    public override void Turn()//nearly identical to the pawn controller move decision, but it wants to be more than 2 tiles away.
    {
        if (Vector2Int.Distance(currentTile.position, tileaccess.playerPos) < vision)
        {
            movesound.Play();
            float distance = 1000; //if they're more than 1000 tiles away they dont deserve to move
            Vector2Int best = currentTile.position; //
            foreach (Vector2Int i in movetiles)
            {
                Vector2Int prospect = currentTile.position + i;
                if (prospect == tileaccess.playerPos)
                {
                    tileaccess.tileDict[prospect].moveTo(this);
                    return;
                }
                float pdist = Vector2Int.Distance(prospect, tileaccess.playerPos);
                if (tileaccess.tileDict.ContainsKey(prospect) && tileaccess.tileDict[prospect].occupant == null && pdist < distance && pdist > 2)
                {
                    best = prospect;
                    distance = pdist;
                }
            }
            tileaccess.tileDict[best].moveTo(this);
        }
    }
    public override void death(basecontroller attacker)
    {

        tileaccess.energy +=1;
        DestroyImmediate(this.gameObject); //destoryed objects = null
    }
}
