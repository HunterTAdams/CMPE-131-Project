using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playercontroller : basecontroller
{
    public GameObject[] movementtiles;
    public Text energytext;
    public int health;
    public AudioSource hurtsound;
    public GameObject[] hearts;
    public GameObject healthbutton;
    public AudioSource turnsound;
    public DeathSystem die;


    
    public override void Turn()
    {
        // turnsound.Play(); removing this for now
        tileaccess.isPlayerTurn = true;
        if (tileaccess.energy >= 5 && health <3)
        {
            healthbutton.SetActive(true);
        }
        foreach(GameObject i in movementtiles)
        {
            i.SetActive(true);
        }
        Color tmp = GetComponent<SpriteRenderer>().color;
        tmp.a = .5f;
        GetComponent<SpriteRenderer>().color = tmp;
    }
    public void endTurn()
    {
        foreach (GameObject i in movementtiles)
        {
            i.SetActive(false);
        }
        healthbutton.SetActive(false);
        tileaccess.isPlayerTurn = false;
        tileaccess.playerPos = currentTile.position;
        energytext.text = tileaccess.energy.ToString();
        Color tmp = GetComponent<SpriteRenderer>().color;
        tmp.a = 1f;
        GetComponent<SpriteRenderer>().color = tmp;
        //update energy here
        
    }

    public void addhealth()
    {
        health += 1;
        tileaccess.energy -= 5;
        for (int i = 3; i > 0; i--)//copy this to wherever health is updated
        {
            hearts[i - 1].SetActive(true);
            if (i > health)
            {
                hearts[i - 1].SetActive(false);
            }
        }
        endTurn();
    }

    public override void death(basecontroller attacker)
    {
        //for the player specifically, this decrements a healthbar and then ends the game if the health bar is 0
        health += -1;
        energytext.text = tileaccess.energy.ToString();
        StartCoroutine(flashred(attacker));
        //update healthbar here
        hurtsound.Play();
        if(health == 0) die.death(); 
        for(int i = 3; i > 0; i--)//copy this to wherever health is updated
        {
            hearts[i - 1].SetActive(true);
            if(i > health)
            {
                hearts[i - 1].SetActive(false);
            }
        }

    }
    private IEnumerator flashred(basecontroller attacker)
    {
        Color tmp = attacker.gameObject.GetComponent<SpriteRenderer>().color;
        tmp.g = 0f;
        attacker.gameObject.GetComponent<SpriteRenderer>().color = tmp;
        yield return new WaitForSeconds(.4f);
        tmp = attacker.gameObject.GetComponent<SpriteRenderer>().color;
        tmp.g = 1f;
        attacker.gameObject.GetComponent<SpriteRenderer>().color = tmp;
    }
}
