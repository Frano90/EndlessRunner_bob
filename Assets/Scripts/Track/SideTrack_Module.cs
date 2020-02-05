using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideTrack_Module : TrackObject
{
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveTowardsCamera();
    }

    /// <summary>
    /// Movimiento de los modulos
    /// </summary>
    private void MoveTowardsCamera()
    {
        _rb.MovePosition(_rb.position + (Vector3.back * _trackConfig.speed * Time.fixedDeltaTime));
    }
}
