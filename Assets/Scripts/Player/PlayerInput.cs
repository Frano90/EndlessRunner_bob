using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //Esta por verse si uso esto. 
    //Creo que si uso los booleans, voy a tener varios frames con las cosas prendidas,
    //lo que puede llegar a un mal funcionamiento
    public event Action OnRightCommand = delegate {  };
    public event Action OnLeftCommand = delegate {  };
    public event Action OnUpCommand = delegate {  };
    public event Action OnDownCommand = delegate {  };
    public event Action OnCheerCommand = delegate {  };

    
    private void Update()
    {
        ReadInputs();
    }

    private void ReadInputs()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            OnLeftCommand();
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            OnRightCommand();
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            OnUpCommand();
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            OnDownCommand();
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnCheerCommand();
        }
    }
}
