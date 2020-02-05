using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TrackObject : MonoBehaviour, ITrackModuleQueuePool
{
   [SerializeField] protected TrackModule_config _trackConfig;

   private int _queueIndex;

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
}
