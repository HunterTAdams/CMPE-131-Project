using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenController : basecontroller
{
    public override void Turn()
    {

    }
    public override void death()
    {
        tileaccess.deadqueens++;
        DestroyImmediate(this.gameObject); //destoryed objects = null
    }
}
