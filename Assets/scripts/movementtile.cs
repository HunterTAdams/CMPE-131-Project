using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementtile : MonoBehaviour
{
    public bool isRookMove;
    public bool isKnightMove;
    public bool isBishMove;
    public Vector2Int movement;
    public playercontroller king;
    void OnEnable()
    {
        if (!tileaccess.tileDict.ContainsKey(king.currentTile.position + movement) | (isRookMove && (tileaccess.deadrooks == 0 && tileaccess.deadqueens == 0)) | (isBishMove && (tileaccess.deadbishs == 0 && tileaccess.deadqueens == 0)) | (isKnightMove && tileaccess.deadknights == 0))
        {
            this.gameObject.SetActive(false);
        }
    }
    void OnMouseDown()//apparently this only calls when... a collider on the object is clicked. i guess it works but i dont like it.
    {
        if (isRookMove)
        {
            if (tileaccess.deadrooks > 0)
            {
                tileaccess.deadrooks += -1;
            }
            else tileaccess.deadqueens += -1;
        }
        else if (isBishMove)
        {
            if (tileaccess.deadbishs > 0)
            {
                tileaccess.deadbishs += -1;
            }
            else tileaccess.deadqueens += -1;
        }
        else if (isKnightMove)
        {
            tileaccess.deadknights += -1;
        }
        
        if (!tileaccess.tileDict[king.currentTile.position + movement].moveTo(king))
        {
            tileaccess.tileDict[king.currentTile.position + movement].moveTo(king); //the king does this twice to both take and replace the target piece
        }
        king.endTurn();
    }
}
