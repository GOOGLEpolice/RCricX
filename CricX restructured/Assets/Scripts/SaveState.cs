using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SaveState 
{
    public int HighScore {set; get;}

    public List<int> PlayerDeck {set; get;}
    public List<int> OpponentDeck { set; get; }

    public DateTime LastSaveTime { set; get;}
}
