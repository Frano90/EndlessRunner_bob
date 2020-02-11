using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skybox_handler : MonoBehaviour
{
    [SerializeField] private float _speed;

    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", _speed * Time.time);
    }
}
