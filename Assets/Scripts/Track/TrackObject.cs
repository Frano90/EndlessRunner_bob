using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class TrackObject : MonoBehaviour, ITrackModuleQueuePool
{
   [SerializeField] protected TrackModule_config _trackConfig;
   protected Rigidbody _rb;
   
   private int _queueIndex;

   protected bool isSettingHorizon = false;

   private void Start()
   {
      _rb = GetComponent<Rigidbody>();
   }
   
   public int QueueIndex
   {
      get { return _queueIndex; }
      set
      {
         if (_queueIndex == default)
            _queueIndex = value;
         else
         {
            throw new System.Exception("Bad pool use, this should only set once!");
         }
      }
   }
   
   //Tengo que ver la manera de hacer que cuando suban, se encastren bien uno tras otro
   protected void MoveTowardsCamera()
   {

      if (isSettingHorizon)
      {
         _rb.MovePosition(_rb.position + (Vector3.up * _trackConfig.speed * Time.fixedDeltaTime));
      }
      else
      {
         _rb.MovePosition(_rb.position + (Vector3.back * _trackConfig.speed * Time.fixedDeltaTime));    
      }
 
   }

   private void Update()
   {
      if (transform.localPosition.y >= 0)
      {
         transform.localPosition = new Vector3(transform.localPosition.x, 0, transform.localPosition.z);
         isSettingHorizon = false;
      }
   }

   public void SetHorizon(TrackObject lastTrack)
   {
      
      isSettingHorizon = true;
   }
}
