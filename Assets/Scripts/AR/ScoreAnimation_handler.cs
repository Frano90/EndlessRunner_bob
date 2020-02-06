using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAnimation_handler : MonoBehaviour
{
    [SerializeField] private Animator _scoreAnimator;

    
    
    public void DoTheJellySpin()
    {
        _scoreAnimator.SetTrigger("JellySpin");
    }
}
