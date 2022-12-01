using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movementtile : MonoBehaviour
{
    
    public Vector2Int movement;
    public playercontroller king;
    public int cost;
    public Text costdisplay;
    public Text costdisplayHUD;
    public AudioSource hoversound;
    public AudioSource clicksound;
    public AudioSource takesound;


    void OnEnable()
    {
        Color tmp = GetComponent<SpriteRenderer>().color;
        tmp.a = .5f;
        GetComponent<SpriteRenderer>().color = tmp;
        if ((!tileaccess.tileDict.ContainsKey(king.currentTile.position + movement) | tileaccess.energy < cost) || (tileaccess.tileDict[king.currentTile.position + movement].occupant != null && tileaccess.tileDict[king.currentTile.position + movement].occupant.invulnerable))
        {
            this.gameObject.SetActive(false);
            return;
        }
        
    }
    void OnMouseDown()//apparently this only calls when... a collider on the object is clicked. i guess it works but i dont like it.
    {
        if (!Pause.gamePaused && !DeathSystem.dead)
        {
            costdisplay.text = "";
            costdisplayHUD.text = "";

            tileaccess.energy += -cost;
            if (!tileaccess.tileDict[king.currentTile.position + movement].moveTo(king))
            {
                if (!tileaccess.tileDict[king.currentTile.position + movement].occupant.ghost)
                {
                    takesound.Play();
                }
                else clicksound.Play();
                tileaccess.tileDict[king.currentTile.position + movement].moveTo(king); //the king does this twice to both take and replace the target piece
                tileaccess.currentzone.checkdead();
            }
            else
            {
                clicksound.Play();
            }

            king.endTurn();
        }
    }
    void OnMouseEnter()//mouse events only target the first collider they hit. these are at z = -10 so they hit them first, and still let you hover over stuff to see their movement.
    {
        if (!Pause.gamePaused && !DeathSystem.dead)
        {
            hoversound.Play();

            if (cost != 0)
            {
                costdisplay.text = "-" + cost.ToString();
                costdisplayHUD.text = "-" + cost.ToString();
            }

            tileScript target;
            Color tmp = GetComponent<SpriteRenderer>().color;
            tmp.a = 1f;
            GetComponent<SpriteRenderer>().color = tmp;
            if (tileaccess.tileDict.TryGetValue(movement + king.currentTile.position, out target) && target.occupant != null)
            {
                target.occupant.OnMouseEnter();
            }
        }
    }
    void OnMouseExit()
    {
        costdisplay.text = "";
        costdisplayHUD.text = "";
        tileScript target;
        Color tmp = GetComponent<SpriteRenderer>().color;
        tmp.a = .5f;
        GetComponent<SpriteRenderer>().color = tmp;
        if (tileaccess.tileDict.TryGetValue(movement + king.currentTile.position,out target) && target.occupant != null)
        {
            target.occupant.OnMouseExit();
        }
    }
}
