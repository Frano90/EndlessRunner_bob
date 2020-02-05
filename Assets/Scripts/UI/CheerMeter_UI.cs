using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheerMeter_UI : MonoBehaviour
{
    [SerializeField] private CheerMeter_handler _cheerMeterHandler;
    private Scrollbar _scrollbar;

    private void Awake()
    {
        _scrollbar = GetComponent<Scrollbar>();
    }

    private void Update()
    {
        UpdateCheerMeter();
    }

    private void UpdateCheerMeter()
    {
        _scrollbar.value = _cheerMeterHandler.CurrentCheer / 100;
    }
}
