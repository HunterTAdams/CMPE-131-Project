using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : basecontroller
{
    // Start is called before the first frame update


    // Update is called once per frame
    public override void Update()
    { }
    public override void Awake()
    {
        tileaccess.tileDict[new Vector2Int(initposx, initposy)].moveTo(this);
    }
}


