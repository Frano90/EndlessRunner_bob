using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed_handler : MonoBehaviour
{
    [SerializeField] private TrackModule_config _trackModuleConfig;
    [SerializeField] private EntityConfig _entityConfig;
    private CheerMeter_handler _cheerMeterHandler;
    [SerializeField] private float _addTimeToOverExcited;

    private float _timeCount;

    private void Start()
    {
        Coin.OnGetCoin += MaintainOverExcitedState;
        _cheerMeterHandler = GetComponent<CheerMeter_handler>();
    }

    private void Update()
    {
        UpdateSpeed();
    }

    private void UpdateSpeed()
    {
        switch (_cheerMeterHandler._currentCheerStatus)
        {
            case CheerMeter_handler.CheerStatus.desanimado:
            {
                DesanimadoTick();
                break;
            }
            case CheerMeter_handler.CheerStatus.animado:
            {
                AnimadoTick();
                break;
            }
            case CheerMeter_handler.CheerStatus.sobreexitado:
            {
                SobreexitadoTick();
                break;
            }
        }
    }

    private void AnimadoTick()
    {
        ResetTimerForOverExcited();
        
        _trackModuleConfig.speed += _entityConfig.aceleration;

        if (_trackModuleConfig.speed >= _entityConfig.topSpeed)
            _trackModuleConfig.speed = _entityConfig.topSpeed;
    }
    
    private void DesanimadoTick()
    {
        ResetTimerForOverExcited();
            
        _trackModuleConfig.speed -= _entityConfig.decelerate;

        if (_trackModuleConfig.speed <= 0)
            _trackModuleConfig.speed = 0;
    }
    
    private void SobreexitadoTick()
    {
        _timeCount += Time.deltaTime;
    
        _trackModuleConfig.speed += _entityConfig.aceleration;

        if (_trackModuleConfig.speed >= _entityConfig.overExcitedTopSpeed)
            _trackModuleConfig.speed = _entityConfig.overExcitedTopSpeed;
        
        
        if (_timeCount >= _entityConfig.overExitedTime)
        {
            ResetTimerForOverExcited();
            OverExcitedExplode();
        }
    }

    private void OverExcitedExplode()
    {
        _cheerMeterHandler.MinusCheer(_cheerMeterHandler.CurrentCheer);
        _trackModuleConfig.speed = 5;
    }

    private void ResetTimerForOverExcited()
    {
        _timeCount = 0;
    }
    
    private void MaintainOverExcitedState()
    {
        _timeCount -= _addTimeToOverExcited;

        if (_timeCount < 0)
            _timeCount = 0;
    }

    

   
}
