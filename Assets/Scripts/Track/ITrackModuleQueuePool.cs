using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITrackModuleQueuePool
{
    /// <summary>
    /// Sirve para mantener un ID con la cola del pool
    /// </summary>
    int QueueIndex { get; set; }
}
