using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideTrack_Module : TrackObject
{
    private void FixedUpdate()
    {
        MoveTowardsCamera();
    }
}
