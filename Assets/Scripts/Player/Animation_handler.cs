using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_handler : MonoBehaviour
{
    private CheerMeter_handler _cheerMeterHandler;
    [SerializeField] private Animator _animator;
    [SerializeField] private TrackModule_config _trackModuleConfig;

    private void Start()
    {
        _cheerMeterHandler = GetComponent<CheerMeter_handler>();
    }

    private void Update()
    {
        _animator.SetFloat("Speed", _trackModuleConfig.speed);
        _animator.SetFloat("Cheer", _cheerMeterHandler.CurrentCheer);
    }

    public void JumpAnimationTrigger()
    {
        _animator.SetTrigger("Jump");
    }
}
