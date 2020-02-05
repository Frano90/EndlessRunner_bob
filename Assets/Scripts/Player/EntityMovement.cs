using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EntityMovement : Entity
{
    //Lee los inputs del jugador o cerebro
    private Rigidbody _rb;
    [SerializeField] private float _jumpDistance = 3;

    public bool IsMoving { get; private set; }
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    public void GoToPosition(Vector3 newPos)
    {
        StartCoroutine(TranslateToPos(newPos));
        IsMoving = true;
    }

    public void Jump()
    {
        Vector3 originalPos = _rb.position;
        Vector3 jumpPosition = transform.localPosition + new Vector3(0, _jumpDistance, 0);
        
        StartCoroutine(JumpRutine(originalPos, jumpPosition));
        IsMoving = true;
    }

    /// <summary>
    /// Corutina que se encarga de mover al chabon de un lado a otro dependiendo la posicion a la que tiene que ir
    /// </summary>
    /// <param name="newPos"></param>
    /// <returns></returns>
    private IEnumerator TranslateToPos(Vector3 newPos)
    {
        Vector3 dir = newPos - _rb.position;
        Vector3 normDir = dir.normalized;
        
        while (Vector3.Distance(newPos, _rb.position) > .2f)
        {
            _rb.MovePosition(_rb.position + lateralSpeed * normDir * Time.fixedDeltaTime);
            yield return new WaitForFixedUpdate();
        }

        _rb.position = newPos;
        IsMoving = false;
    }

    private IEnumerator JumpRutine(Vector3 originalPos, Vector3 topJumpPosition)
    {
        Vector3 upDir = topJumpPosition - _rb.position;
        Vector3 normUpDir = upDir.normalized;
        
        while (Vector3.Distance(topJumpPosition, _rb.position) > .2f)
        {
            _rb.MovePosition(_rb.position + jumpSpeed * normUpDir * Time.fixedDeltaTime);
            yield return new WaitForFixedUpdate();
        }
        
        Vector3 downDir = originalPos - _rb.position;
        Vector3 normDownDir = downDir.normalized;
        
        while (Vector3.Distance(originalPos, _rb.position) > .2f)
        {
            _rb.MovePosition(_rb.position + jumpSpeed * normDownDir * Time.fixedDeltaTime);
            yield return new WaitForFixedUpdate();
        }

        _rb.position = originalPos;
        IsMoving = false;


    }
    
    
    
    
}
