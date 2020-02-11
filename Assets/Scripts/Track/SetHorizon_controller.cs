using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHorizon_controller : MonoBehaviour
{
    [SerializeField] private UpToHorizon_Trigger _horizonTrigger;

    [SerializeField] private TrackModule _trackModule;
    [SerializeField] private SideTrack_Module _sideTrackModule;
    
    //Este controlador va a decirle a los modulos que hacer, cuando subir o bajar, pero la idea es que los modulos
    //Sean los que vayan hasta las distancias dichas. Solo hay que pasarles a donde hay que moverse
    void Start()
    {
        _horizonTrigger.OnTrackMeetsHorizon += SetHorizon;
        _horizonTrigger.OnTrackMeetsHorizon += RegisterLastModule;
    }

    private void SetHorizon(TrackObject currentTrack)
    {
        currentTrack.SetHorizon(currentTrack);
    }

    private void RegisterLastModule(TrackObject currentTrack)
    {
        if (currentTrack.GetComponent<TrackModule>() != null)
        {
            _trackModule = currentTrack as TrackModule;
        }
        else if(currentTrack.GetComponent<SideTrack_Module>() != null)
        {
            _sideTrackModule = currentTrack as SideTrack_Module;
        }
    }
    
}
