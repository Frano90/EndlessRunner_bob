using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPools_handler : MonoBehaviour
{
    [SerializeField] private GameEvent OnPrewarmFinished;

    private bool trackPrewarmReady;
    private bool sideTrackPrewarmReady;
    
    void Update()
    {
        if (trackPrewarmReady && sideTrackPrewarmReady)
        {
            OnPrewarmFinished.Raise();
            sideTrackPrewarmReady = false;
            trackPrewarmReady = false;
        }
    }

    public void SideTrackRdy()
    {
        sideTrackPrewarmReady = true;
    }
    
    public void TrackRdy()
    {
        trackPrewarmReady = true;
    }
    
}
