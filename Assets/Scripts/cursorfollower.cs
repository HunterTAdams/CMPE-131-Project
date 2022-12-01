using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorfollower : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Input.mousePosition + new Vector3(20, 20, 0);
    }
}
