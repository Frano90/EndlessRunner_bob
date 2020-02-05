using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : TrackElement
{
    public int cheerDrop;
    
    public static event Action<Obstacle> OnCollideWithObstacle = delegate {  };
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EntityMovement>() != null)
        {
            OnCollideWithObstacle(this);
            //Destroy(gameObject);
        }
    
    }
}
