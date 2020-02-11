using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingBalance_handler : MonoBehaviour
{
    [SerializeField] private EntityConfig _playerSettings;
    [SerializeField] private EntityConfig _playerSettings_BASE;

    [SerializeField] private InputField _topSpeed;
    [SerializeField] private InputField _overExcitedTopSpeed;

    public void Reset()
    {
        _playerSettings.topSpeed = _playerSettings_BASE.topSpeed;
        _playerSettings.overExcitedTopSpeed = _playerSettings_BASE.overExcitedTopSpeed;
    }

    public void SaveChanges()
    {
        if (_overExcitedTopSpeed.text == "" || _topSpeed.text == "")
            return;
        
        _playerSettings.topSpeed = float.Parse( _topSpeed.text);
        _playerSettings.overExcitedTopSpeed = float.Parse(_overExcitedTopSpeed.text);
    }
    
    
}
