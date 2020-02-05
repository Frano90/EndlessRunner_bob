using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnEnable()
    {
        gameObject.SetActive(true);
    }

    public static event Action OnGetCoin = delegate {  };
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EntityMovement>() != null)
        {
            OnGetCoin();
            gameObject.SetActive(false);
        }
    }
}
