using System;
using UnityEngine;

public class ReturnSideTrack_trigger : MonoBehaviour
{
    public event Action<SideTrack_Module> OnReturnModuleToPool = delegate {  };
    private void OnTriggerEnter(Collider other)
    {
        SideTrack_Module lastModule = other.transform.parent.GetComponent<SideTrack_Module>();
        if (lastModule != null)
        {
            OnReturnModuleToPool(lastModule);
        }
    }
}
