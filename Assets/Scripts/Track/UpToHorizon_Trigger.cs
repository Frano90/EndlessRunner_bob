using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpToHorizon_Trigger : MonoBehaviour
{
    public event Action<TrackObject> OnTrackMeetsHorizon = delegate {  };

    private void OnTriggerEnter(Collider other)
    {
        TrackObject lastModule = other.transform.parent.GetComponent<TrackObject>();

        if (lastModule != null) //&& lastModule.gameObject.layer == 10)
        {
            OnTrackMeetsHorizon(lastModule);
        }
    }
}
