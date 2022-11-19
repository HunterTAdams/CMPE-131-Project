using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopController : basecontroller
{
    public override void Turn()
    {

    }
    public override void death()
    {
        tileaccess.deadbishs++;
        DestroyImmediate(this.gameObject); //destoryed objects = null
    }
}
