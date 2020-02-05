using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapDetector : MonoBehaviour
{
    public static event Action OnTap = delegate { };
    
    private Vector2 fingerDownPosition;
    private Vector2 fingerUpPosition;
    
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                fingerDownPosition = touch.position;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                fingerUpPosition = touch.position;
                
                if (Vector2.Distance(fingerDownPosition, fingerUpPosition) < 40)
                {
                    OnTap();
                }
            }
        }
    }
}
