using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

//pulls info from card fucntions and Stores the game objects in a list

public class OppDeckEventManager : MonoBehaviour
{

    public static OppDeckEventManager instance;
    public List<GameObject> opponentDeck1 = new List<GameObject>(11);
    public List<int> oppId;
    public List<GameObject> deck;
    
    /*public List<GameObject> Deck2 = new List<GameObject>();
    public List<GameObject> Deck3 = new List<GameObject>();
    public List<GameObject> Deck4 = new List<GameObject>();
    public List<GameObject> Deck5 = new List<GameObject>();*/
    public List<Transform> DeckSlots;
    public List<Transform> SpawnSlots;
    private void Awake()
    {
        
        instance = this;
        

        
    }

    public event Action<int> onAddButtonPress;//parameter int id. this int value should be different on all cards to be able to differentiate from each other.

    public void AddButtonPressed(int opId)
    {
        if(onAddButtonPress != null)
        {
            onAddButtonPress(opId);
            
        }
    }
    public event Action<int> onRemoveButtonPress;
    public void RemoveButtonPressed(int opId)
    {
        if(onRemoveButtonPress != null)
        { 
            onRemoveButtonPress(opId);
        }
    }

    private void Start()
    {
        
        
    }

    public void OnSceneChange()
    {

        opponentDeck1.Clear();
        if(oppId.Count >0)
        {
            foreach(int oppId in oppId)
            {
                 
                for(int i = 0; i < deck.Count; i++)
                {
                    if(oppId == deck[i].GetComponent<OppCardFunctions>().opId)
                    {
                        opponentDeck1.Add(deck[i]);
                    }
                }
            }
        }
    }
    public void GameSceneLoad()
    {
        SceneManager.LoadScene(sceneName: "SampleScene");
    }
}
