using System;
using UnityEngine;

public class EndSideTrack_trigger : MonoBehaviour
{
    public event Action<SideTrack_Module> OnLastTrackModule = delegate {  };

    private void OnTriggerExit(Collider other)
    {
        SideTrack_Module lastModule = other.transform.parent.GetComponent<SideTrack_Module>();
        
        if (lastModule != null && lastModule.gameObject.layer == 11)
        {
            OnLastTrackModule(lastModule);
        }
    }
}
