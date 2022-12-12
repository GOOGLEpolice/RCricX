using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SaveState
{
    private static SaveState _state;
    public static SaveState state
    {
        get
        {
            if (_state == null)
            {
                _state = new SaveState();
            }
            return _state; } 
        set
        {
            _state = value;
        }
    }


    public List<int> PlayerDeck {set; get;}
    

    
}
