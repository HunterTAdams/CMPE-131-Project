using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pawncontroller : basecontroller //fast piece that creates most of the pressure preventing the player from singling out other pieces safely
{
    public Vector2Int[] movetiles = new Vector2Int[4];
    public override void Turn()
    {
        if (Vector2Int.Distance(currentTile.position, tileaccess.playerPos) < vision)
        {
            movesound.Play();
            if (tileaccess.playerPos == currentTile.position + Vector2Int.down + Vector2Int.left || tileaccess.playerPos == currentTile.position + Vector2Int.down + Vector2Int.right || tileaccess.playerPos == currentTile.position + Vector2Int.up + Vector2Int.left || tileaccess.playerPos == currentTile.position + Vector2Int.up + Vector2Int.right)
            {
                tileaccess.tileDict[tileaccess.playerPos].moveTo(this);
            }
            else
            {
                float distance = 1000; //if they're more than 1000 tiles away they dont deserve to move
                Vector2Int best = currentTile.position; //
                foreach (Vector2Int i in movetiles)
                {
                    Vector2Int prospect = currentTile.position + i;
                    float pdist = Vector2Int.Distance(prospect, tileaccess.playerPos);
                    if (tileaccess.tileDict.ContainsKey(prospect) && tileaccess.tileDict[prospect].occupant == null && pdist < distance)
                    {
                        best = prospect;
                        distance = pdist;
                    }
                }
                tileaccess.tileDict[best].moveTo(this);


            }
        }
        
    }
    public override void death(basecontroller attacker)
    {

        tileaccess.energy += 1;
        DestroyImmediate(this.gameObject); //destoryed objects = null
    }
    /*public override void OnMouseEnter()
    {
        foreach(GameObject i in hovermoveshow)
        {
            i.SetActive(true);
        }
    }
    public override void OnMouseExit()
    {
        foreach(GameObject i in hovermoveshow)
        {
            i.SetActive(false);
        }
    }*/
    //this is the bit associated with showing a piece's movement when they are hovered over. unfinished, disabled for the prerelase version, will be revamped for the release.
}
