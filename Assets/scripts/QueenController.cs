using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenController : basecontroller//alternates between rook and bishop ai.
{

    public bool alternate;
    public override void Turn()
    {
        movesound.Play();
        Vector2Int[] movetiles = new Vector2Int[64];
        for (int i = 0; i < 64; i++)
        {
            movetiles[i] = new Vector2Int(-100000, -100000);
        }
        for (int i = 1; i <= 8; i++)
        {

            Vector2Int prospect = currentTile.position + new Vector2Int(i, i);
            if (prospect == tileaccess.playerPos)
            {
                tileaccess.tileDict[prospect].moveTo(this);
                return;
            }
            if (tileaccess.tileDict.ContainsKey(prospect) && tileaccess.tileDict[prospect].occupant == null)
            {
                movetiles[i - 1] = prospect;
            }
            else break;
        }
        for (int i = 1; i <= 8; i++)
        {
            Vector2Int prospect = currentTile.position + new Vector2Int(-i, i);
            if (prospect == tileaccess.playerPos)
            {
                tileaccess.tileDict[prospect].moveTo(this);
                return;
            }
            if (tileaccess.tileDict.ContainsKey(prospect) && tileaccess.tileDict[prospect].occupant == null)
            {
                movetiles[i + 7] = prospect;
            }
            else break;
        }
        for (int i = 1; i <= 8; i++)
        {
            Vector2Int prospect = currentTile.position + new Vector2Int(i, -i);
            if (prospect == tileaccess.playerPos)
            {
                tileaccess.tileDict[prospect].moveTo(this);
                return;
            }
            if (tileaccess.tileDict.ContainsKey(prospect) && tileaccess.tileDict[prospect].occupant == null)
            {
                movetiles[i + 15] = prospect;
            }
            else break;
        }
        for (int i = 1; i <= 8; i++)
        {
            Vector2Int prospect = currentTile.position + new Vector2Int(-i, -i);
            if (prospect == tileaccess.playerPos)
            {
                tileaccess.tileDict[prospect].moveTo(this);
                return;
            }
            if (tileaccess.tileDict.ContainsKey(prospect) && tileaccess.tileDict[prospect].occupant == null)
            {
                movetiles[i + 23] = prospect;
            }
            else break;
        }
        for (int i = 1; i <= 8; i++)
        {

            Vector2Int prospect = currentTile.position + new Vector2Int(i, 0);
            if (prospect == tileaccess.playerPos)
            {
                tileaccess.tileDict[prospect].moveTo(this);
                return;
            }
            if (tileaccess.tileDict.ContainsKey(prospect) && tileaccess.tileDict[prospect].occupant == null)
            {
                movetiles[i + 31] = prospect;
            }
            else break;
        }
        for (int i = 1; i <= 8; i++)
        {
            Vector2Int prospect = currentTile.position + new Vector2Int(-i, 0);
            if (prospect == tileaccess.playerPos)
            {
                tileaccess.tileDict[prospect].moveTo(this);
                return;
            }
            if (tileaccess.tileDict.ContainsKey(prospect) && tileaccess.tileDict[prospect].occupant == null)
            {
                movetiles[i + 39] = prospect;
            }
            else break;
        }
        for (int i = 1; i <= 8; i++)
        {
            Vector2Int prospect = currentTile.position + new Vector2Int(0, i);
            if (prospect == tileaccess.playerPos)
            {
                tileaccess.tileDict[prospect].moveTo(this);
                return;
            }
            if (tileaccess.tileDict.ContainsKey(prospect) && tileaccess.tileDict[prospect].occupant == null)
            {
                movetiles[i + 47] = prospect;
            }
            else break;
        }
        for (int i = 1; i <= 8; i++)
        {
            Vector2Int prospect = currentTile.position + new Vector2Int(0, -i);
            if (prospect == tileaccess.playerPos)
            {
                tileaccess.tileDict[prospect].moveTo(this);
                return;
            }
            if (tileaccess.tileDict.ContainsKey(prospect) && tileaccess.tileDict[prospect].occupant == null)
            {
                movetiles[i + 55] = prospect;
            }
            else break;
        }
        if(alternate)
        {
            alternate = false;
            float curscore = 10000;
            Vector2Int best = currentTile.position; //
            foreach (Vector2Int prospect in movetiles)
            {
                float pdist = Vector2Int.Distance(prospect, tileaccess.playerPos);
                float score = 0;
                if (prospect.x == tileaccess.playerPos.x || prospect.y == tileaccess.playerPos.y) score += -100;
                score += (pdist - 7) * (pdist - 7);
                if (pdist > 12) score += pdist * 100;
                if (curscore > score)
                {
                    curscore = score;
                    best = prospect;
                }


            }
            tileaccess.tileDict[best].moveTo(this);
        }
        else
        {
            alternate = true;
            float curscore = 10000;
            Vector2Int best = currentTile.position; //
            foreach (Vector2Int prospect in movetiles)
            {
                float pdist = Vector2Int.Distance(prospect, tileaccess.playerPos);
                float score = (prospect.x - tileaccess.playerPos.x) - (prospect.y - tileaccess.playerPos.y);
                score = (score * score) * 400;
                score += -pdist;
                if (pdist > 7) score += pdist * 100;
                if (curscore > score)
                {
                    curscore = score;
                    best = prospect;
                }


            }
            tileaccess.tileDict[best].moveTo(this);
        }
    }
    public override void death(basecontroller attacker)
    {

        tileaccess.energy += 10;
        DestroyImmediate(this.gameObject); //destoryed objects = null
    }
}
