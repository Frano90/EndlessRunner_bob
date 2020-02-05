using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TrackModule config",menuName = "Track/ModuleConfig")]
public class TrackModule_config : ScriptableObject
{
    private void OnEnable()
    {
        speed = 0;
    }

    public float speed;
}
