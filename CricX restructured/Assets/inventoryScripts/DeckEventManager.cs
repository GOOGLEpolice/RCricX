using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//pulls info from card fucntions and Stores the game objects in a list

public class DeckEventManager : MonoBehaviour
{
    bool deck1;
    bool deck2;
    bool deck3;
    bool deck4;
    bool deck5;

    public static DeckEventManager instance;
    public List<GameObject> DeckT = new List<GameObject>(11);
    
    public List<GameObject> Deck2 = new List<GameObject>();
    public List<GameObject> Deck3 = new List<GameObject>();
    public List<GameObject> Deck4 = new List<GameObject>();
    public List<GameObject> Deck5 = new List<GameObject>();
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

    public void GameSceneLoad()
    {
        SceneManager.LoadScene(sceneName: "SampleScene");
    }
}
