using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Entity configuration", menuName = "Entity configuration")]
public class EntityConfig : ScriptableObject
{
    public Vector4 cheerMeterRange;
    public float topSpeed;
    public float aceleration;
    public float decelerate;
    public float reactionTime;
    public float constantMinusCheer;
    public float minusCheerTimeInterval;
    public float constantAddCheerAmount;
    public float overExitedTime;
    public float overExcitedTopSpeed;
}
