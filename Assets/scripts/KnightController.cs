using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : basecontroller
{
    public override void Turn()
    {

    }
    public override void death()
    {
        tileaccess.deadknights++;
        DestroyImmediate(this.gameObject); //destoryed objects = null
    }
}
