using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiletrigger : wall
{
    public GameObject nextzone;
    public override void death(basecontroller attacker)
    {
        nextzone.SetActive(true);
        DestroyImmediate(this.gameObject);
    }
}
