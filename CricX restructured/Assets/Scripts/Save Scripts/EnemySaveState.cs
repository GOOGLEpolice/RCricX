using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class EnemySaveState
{
    private static EnemySaveState _estate;
    public static EnemySaveState estate
    {
        get
        {
            if (_estate == null)
            {
                _estate = new EnemySaveState();
            }
            return _estate;
        }
        set
        {
            _estate = value;
        }
    }


    public List<int> OpponentDeck { set; get; }
   
}
