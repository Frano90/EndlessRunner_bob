using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrack_Trigger : MonoBehaviour
{
    public event Action<TrackModule> OnLastTrackModule = delegate {  };

    private void OnTriggerExit(Collider other)
    {
        TrackModule lastModule = other.transform.parent.GetComponent<TrackModule>();
        
        if (lastModule != null && lastModule.gameObject.layer == 10)
        {
            OnLastTrackModule(lastModule);
        }
    }
}
