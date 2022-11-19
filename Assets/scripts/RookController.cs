using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RookController : basecontroller
{
    public override void Turn()
    {
        
    }
    public override void death()
    {
        tileaccess.deadrooks++;
        DestroyImmediate(this.gameObject); //destoryed objects = null
    }
}
