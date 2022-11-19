using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pawncontroller : basecontroller
{
    public override void Turn()
    {

    }
    public override void death()
    {
        DestroyImmediate(this.gameObject); //destoryed objects = null
    }
}
