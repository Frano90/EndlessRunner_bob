using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrackModule : TrackObject
{
    private void FixedUpdate()
    {
        MoveTowardsCamera();
    }
    
    
}
