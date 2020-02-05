using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericPoolWithMultipleObjects<T> : MonoBehaviour where T : Component
{
     /// <summary>
     /// Singleton del pool
     /// </summary>
    public static GenericPoolWithMultipleObjects<T> Instance { get; private set; }
    /// <summary>
    /// lista de prefabs a poolear
    /// </summary>
    [SerializeField] private List<T> prefabs = new List<T>();
    /// <summary>
    /// Lista de colas donde se alojan los objetos creados
    /// </summary>
    [HideInInspector] public List<Queue<T>> tracksModules = new List<Queue<T>>();
    /// <summary>
    /// cantidad de objetos a crear en cada queue
    /// </summary>
    [SerializeField] private int amountOfPreCreatedObjects;

    /// <summary>
    /// evento que se dispara cuando se termina de crear el prewarm
    /// </summary>
    [SerializeField] private GameEvent OnFinishPreWarmPool;

    #region Init and set of pool

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        InitData();
        //PreWarmPoolObjects();
    }

    /// <summary>
    /// Inicializa las estructuras para laburar
    /// </summary>
    private void InitData()
    {
        for (int i = 0; i < prefabs.Count; i++)
        {
            Queue<T> nuevaCola = new Queue<T>();
            tracksModules.Add(nuevaCola);
        }
    }

    /// <summary>
    /// Objetos creados antes de arrancar para ya tener 
    /// </summary>
    public void PreWarmPoolObjects()
    {

       StartCoroutine(PreWarm_CoRoutine());

    }

    private IEnumerator PreWarm_CoRoutine()
    {
        for (int i = 0; i < prefabs.Count; i++)
        {
            for (int j = 0; j < amountOfPreCreatedObjects; j++)
            {
                AddObjectToQueue(i);
                yield return 0;
            }
        }
        
        OnFinishPreWarmPool.Raise();
    }

    #endregion

    #region Pool Actions

    /// <summary>
    /// Te da un item del pool. Especificar de que queue lo queres
    /// </summary>
    /// <param name="queueIndex"></param>
    /// <returns></returns>
    public T Get(int queueIndex)
    {
        if (tracksModules[queueIndex].Count == 0)
        {
            AddObjectToQueue(queueIndex);
        }

        T trackModule = tracksModules[queueIndex].Dequeue();
        trackModule.gameObject.SetActive(true);
        return trackModule;
    }

    /// <summary>
    /// Devuelve un objeto al pool. Solo hay que devolverlo, no se tiene que especificar de que queue era, para eso
    /// esta la interfaz que lo guarda
    /// </summary>
    /// <param name="objectToReturn"></param>
    public void ReturnToPool(T objectToReturn)
    {
        objectToReturn.gameObject.SetActive(false);
        int trackIndex = objectToReturn.GetComponent<ITrackModuleQueuePool>().QueueIndex;
        
        tracksModules[trackIndex].Enqueue(objectToReturn);
    }

    /// <summary>
    /// Agrega a la queue correspondiente un objeto y le dice a la interfaz de que queue era para luego poder guardarlo
    /// </summary>
    /// <param name="queueIndex"></param>
    private void AddObjectToQueue(int queueIndex)
    {
        var newObject = GameObject.Instantiate(prefabs[queueIndex], transform);
        newObject.gameObject.SetActive(false);
        tracksModules[queueIndex].Enqueue(newObject);

        newObject.GetComponent<ITrackModuleQueuePool>().QueueIndex = queueIndex;
    }
    

    #endregion

}
