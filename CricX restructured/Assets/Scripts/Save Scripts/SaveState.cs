using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SaveState 
{
    

    public List<int> PlayerDeck {set; get;}
    

    public DateTime LastSaveTime { set; get;}
}
