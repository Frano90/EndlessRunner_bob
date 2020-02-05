using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
    private Vector2 fingerDownPosition;
    private Vector2 fingerUpPosition;
    [SerializeField] private bool detectSwipeOnlyAfterRelease = false;

    [SerializeField] private float minDistanceForSwipe = 20f;

    public static event Action<SwipeData> OnSwipe = delegate { };
    private bool isSendingData = false;
    
    
    void Update()
    {
        ReadSwipes();
    }

    private void ReadSwipes()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUpPosition = touch.position;
                fingerDownPosition = touch.position;
            }

            if (!detectSwipeOnlyAfterRelease && touch.phase == TouchPhase.Moved && !isSendingData)
            {
                fingerDownPosition = touch.position;
                DetectSwipe();
            }

//            if (touch.phase == TouchPhase.Ended)
//            {
//                fingerDownPosition = touch.position;
//                DetectSwipe();
//            }

            
        }
    }

    private void DetectSwipe()
    {
        if (SwipeDistanceCheckMet() && !isSendingData)
        {
            if (IsVerticalSwipe())
            {
                var direction = fingerDownPosition.y - fingerUpPosition.y > 0 ? SwipeDirection.Up : SwipeDirection.Down;
                SendSwipe(direction);
            }
            else
            {
                var direction = fingerDownPosition.x - fingerUpPosition.x > 0 ? SwipeDirection.Right : SwipeDirection.Left;
                SendSwipe(direction);
            }
            fingerUpPosition = fingerDownPosition;
        }
    }

    private bool IsVerticalSwipe()
    {
        return VerticalMoventDistance() > HorizontalMovementDistance();
    }

    private bool SwipeDistanceCheckMet()
    {
        return VerticalMoventDistance() > minDistanceForSwipe || HorizontalMovementDistance() > minDistanceForSwipe;
    }
    
    private float VerticalMoventDistance()
    {
        return Mathf.Abs(fingerDownPosition.y - fingerUpPosition.y);
    }

    private float HorizontalMovementDistance()
    {
        return Mathf.Abs(fingerDownPosition.x - fingerUpPosition.x);
    }

    private void SendSwipe(SwipeDirection direction)
    {
        SwipeData swipeData = new SwipeData()
        {
            Direction = direction,
            StartPos = fingerDownPosition,
            EndPos = fingerUpPosition
        };
        OnSwipe(swipeData);
    }
}

public struct SwipeData
{
    public Vector2 StartPos;
    public Vector2 EndPos;
    public SwipeDirection Direction;
}

public enum SwipeDirection
{
    Up,
    Down,
    Left,
    Right
}
