using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//pulls info from card fucntions and Stores the game objects in a list

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

    public event Action<int> onAddButtonPress;//parameter int id. this int value should be different on all cards to be able to differentiate from each other.
    

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
