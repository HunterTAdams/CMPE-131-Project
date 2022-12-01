using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopController : basecontroller//Slow piece that forces you to make yourself vulnerable to to approach
{
    public override void Turn() //generates valid move list. 
    {
        if (Vector2Int.Distance(currentTile.position, tileaccess.playerPos) < 20)
        {
            movesound.Play();
            Vector2Int[] movetiles = new Vector2Int[32];
            for (int i = 0; i < 32; i++)
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

            float curscore = 10000;
            Vector2Int best = currentTile.position; //
            foreach (Vector2Int prospect in movetiles)
            {
                float pdist = Vector2Int.Distance(prospect, tileaccess.playerPos);
                float score = (prospect.x - tileaccess.playerPos.x) - (prospect.y - tileaccess.playerPos.y);
                score = (score * score) * 3;
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

        tileaccess.energy += 3;
        DestroyImmediate(this.gameObject); //destoryed objects = null
    }
}
