using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playercontroller : basecontroller
{
    public GameObject[] movementtiles;
    public Text hudtext;
    public int health;
    public override void Turn()
    {
        tileaccess.isPlayerTurn = true;
        foreach(GameObject i in movementtiles)
        {
            i.SetActive(true);
        }
    }
    public void endTurn()
    {
        foreach (GameObject i in movementtiles)
        {
            i.SetActive(false);
        }
        tileaccess.isPlayerTurn = false;
        tileaccess.playerPos = currentTile.position;
        hudtext.text = "Biships: " + tileaccess.deadbishs + ", Rooks: " + tileaccess.deadrooks + ", Knights: " + tileaccess.deadknights + ", Queens: " + tileaccess.deadqueens + ", Position: " + tileaccess.playerPos.x + " " + tileaccess.playerPos.y + ", Health: " + health; //this stuff will be replaced by an actual hud that updates values in more careful places. for now this works.
    }

    public override void death()
    {
        //for the player specifically, this decrements a healthbar and then ends the game if the health bar is 0
        health += -1;
    }
}
