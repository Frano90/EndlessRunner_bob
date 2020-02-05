using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheerMeter_handler : MonoBehaviour
{
    public float CurrentCheer { get; private set; }
    public CheerStatus _currentCheerStatus {get; private set; }
    [SerializeField] private EntityConfig _entityConfig;
    
    
    private float _timeCount = 0;

    public void AddCheer()
    {
        CurrentCheer += _entityConfig.constantAddCheerAmount;

        if (CurrentCheer >= _entityConfig.cheerMeterRange.w)
        {
            CurrentCheer = _entityConfig.cheerMeterRange.w;
        }
    }

    public void MinusCheer(float cheerAmount)
    {
        CurrentCheer -= cheerAmount;

        if (CurrentCheer < _entityConfig.cheerMeterRange.x)
        {
            CurrentCheer = _entityConfig.cheerMeterRange.x;
        }
    }

    private void Update()
    {
        MinusCheerInterval();
        CheerInputRead();
    }
    
    private void CheerInputRead()
    {
        if (CurrentCheer < _entityConfig.cheerMeterRange.y)
        {
            _currentCheerStatus = CheerStatus.desanimado;
        }
        else if (CurrentCheer < _entityConfig.cheerMeterRange.z)
        {
            _currentCheerStatus = CheerStatus.animado;
        }
        else
        {
            _currentCheerStatus = CheerStatus.sobreexitado;
        }
    }

    public enum CheerStatus
    {
        desanimado,
        animado,
        sobreexitado 
    }

    private void MinusCheerInterval()
    {
        _timeCount += Time.deltaTime;

        if (_timeCount >= _entityConfig.minusCheerTimeInterval)
        {
            _timeCount = 0;
            MinusCheer(_entityConfig.constantMinusCheer);
        }
    }
}
