using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpeedSimulation : MonoBehaviour
{
    private Vector3 _normalPos;
    [SerializeField] private Vector3 _simulatedBoostPos;

    [SerializeField] private bool IsOverExcited = false;
    
    
    [SerializeField] private TrackModule_config _trackModuleConfig;
    [SerializeField] private EntityConfig _playerConfig;
    private void Update()
    {
        if (_trackModuleConfig.speed <= _playerConfig.topSpeed)
        {
            IsOverExcited = false;
            return;
        }

        if (_trackModuleConfig.speed <= _playerConfig.overExcitedTopSpeed)
        {
            IsOverExcited = true;
        }
        
        
    }

    

    
    public float smoothSpeed = 1.25f;
    private void Start()
    {
        _normalPos = transform.position;
    }

    private void SimulateTurbo()
    {
        if (Vector3.Distance(transform.position, _simulatedBoostPos) <= .01f)
        {
            transform.position = _simulatedBoostPos;
            return;
        }
            
        
        GoTo(_simulatedBoostPos);
    }

    private void BackToNormal()
    {
        if (Vector3.Distance(transform.position, _normalPos) <= .01f)
        {
            transform.position = _normalPos;
            return;
        }
            
        GoTo(_normalPos);
    }

    private void GoTo(Vector3 pos)
    {
        Vector3 desiredPosition =  pos;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.fixedDeltaTime);
        transform.position = smoothedPosition;
    }
    

    void FixedUpdate ()
    {
        if (IsOverExcited)
        {
            SimulateTurbo();
        }
        else
        {
            BackToNormal();
        }
        
    }

}
