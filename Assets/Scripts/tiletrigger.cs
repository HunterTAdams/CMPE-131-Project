using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//get rid o this too

public class tiletrigger : wall
{
    public GameObject nextzone;
    public DeathSystem deathsystem;
    public Image deathbackground;
    public override void death(basecontroller attacker)
    {
        nextzone.SetActive(true);
        deathsystem.death();//as long as this line is here, all triggers will kill you. its for the prerelease end screen. remove this. remember to also change nextzone back to fall instead of the winmessage it is now on all the triggers after summer.
        deathbackground.color = Color.black;
        DestroyImmediate(this.gameObject);
    }
}
