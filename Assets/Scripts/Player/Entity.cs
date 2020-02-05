using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    /// <summary>
    /// Clase base de personajes con movimiento dentro del juego.
    /// </summary>
    [SerializeField] protected float lateralSpeed = 1;
    [SerializeField] protected float jumpSpeed = 1;
}
