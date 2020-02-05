using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnTrackElements : MonoBehaviour
{

    [SerializeField] private List<GameObject> activableParents;
    
    private void OnEnable()
    {
        foreach (GameObject t in activableParents)
        {
            foreach (Transform go in t.transform)
            {
                go.gameObject.SetActive(true);
            }
        }
    }
}
