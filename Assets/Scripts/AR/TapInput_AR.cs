using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class TapInput_AR : MonoBehaviour
{

    [SerializeField] private Camera _arCamera;
    
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = _arCamera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;
                if (Physics.Raycast(ray, out hitObject))
                {
                    ScoreAnimation_handler scoreAnim = hitObject.transform.GetComponent<ScoreAnimation_handler>();
                    if (scoreAnim != null)
                    {
                        scoreAnim.DoTheJellySpin();
                    }
                }
            }
            
        }
    }
}
