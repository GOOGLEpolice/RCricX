using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SaveState 
{
    public int HighScore {set; get;}

    public List<GameObject> PlayerDeck {set; get;}
    public List<GameObject> OpponentDeck { set; get; }

    public DateTime LastSaveTime { set; get;}
}
