using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckEventManager : MonoBehaviour
{
    public static DeckEventManager instance;
    public List<GameObject> DeckT = new List<GameObject>();
    public List<Transform> DeckSlots;
    public List<Transform> SpawnSlots;
    private void Awake()
    {
        instance = this;
    }

    public event Action<int> onAddButtonPress;
    

    public void AddButtonPressed(int id)
    {
        if(onAddButtonPress != null)
        {
            onAddButtonPress(id);
        }
    }
    public event Action<int> onRemoveButtonPress;
    public void RemoveButtonPressed(int id)
    {
        if(onRemoveButtonPress != null)
        { 
            onRemoveButtonPress(id);
        }
    }
}
