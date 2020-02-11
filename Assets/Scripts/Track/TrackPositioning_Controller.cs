using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPositioning_Controller : MonoBehaviour
{
    [SerializeField] private EndTrack_Trigger _endTrackTrigger;
    [SerializeField] private ReturnTrack_Trigger _returnTrackTrigger;
    // Start is called before the first frame update
    void Start()
    {
        _endTrackTrigger.OnLastTrackModule += AddNewTrackFromLastModule;
        _returnTrackTrigger.OnReturnModuleToPool += ReturnModuleToPool;
    }

    /// <summary>
    /// Agrega un nuevo modulo justo dsp del ultimo que sale
    /// </summary>
    /// <param name="lastModule"></param>
    private void AddNewTrackFromLastModule(TrackModule lastModule)
    {
        MeshRenderer lastModuleRender = lastModule.GetComponentInChildren<MeshRenderer>();
        var newTrackModule = TrackPool.Instance.Get(GetRandomIndexToPickTrackModule());
        newTrackModule.transform.position = new Vector3(0  ,-10,  lastModuleRender.bounds.max.z -0.5f);//lastModuleRender.bounds.max.y,lastModuleRender.bounds.max.z -0.5f);
    }

    /// <summary>
    /// Da un int entre 0 y la cantidad de queues de modulos que hay en el pool
    /// </summary>
    /// <returns></returns>
    private int GetRandomIndexToPickTrackModule()
    {
        return Random.Range(0, TrackPool.Instance.tracksModules.Count);
    }

    /// <summary>
    /// Devuelve el modulo seleccionado a su pool correspondiente.
    /// </summary>
    /// <param name="module"></param>
    private void ReturnModuleToPool(TrackModule module)
    {
        TrackPool.Instance.ReturnToPool(module);
    }
}
