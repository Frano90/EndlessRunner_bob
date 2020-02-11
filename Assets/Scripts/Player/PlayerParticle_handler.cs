using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticle_handler : MonoBehaviour
{
    [SerializeField] private ParticleSystem _trail_PS;
    [SerializeField] private TrackModule_config _trackModuleConfig;
    [SerializeField] private EntityConfig _playerConfig;
    private void Update()
    {
        if (_trackModuleConfig.speed <= 0)
        {
            if (_trail_PS.isPlaying)
            {
                _trail_PS.Stop();
                
            }
            return;
        }
        else
        {
            if (_trail_PS.isStopped)
            {
                _trail_PS.Play();
                
            }
        }

        if (_trackModuleConfig.speed <= _playerConfig.topSpeed)
        {
            SmallBubbles();
            return;
        }

        if (_trackModuleConfig.speed <= _playerConfig.overExcitedTopSpeed)
        {
            BigBubbles();
        }
        
        
    }

    private void BigBubbles()
    { 
        var main = _trail_PS.main; 
        main.startSpeed = 5;
    }

    private void SmallBubbles()
    {
        
        var main = _trail_PS.main; 
        main.startSpeed = 2;
    }
    
    
}
