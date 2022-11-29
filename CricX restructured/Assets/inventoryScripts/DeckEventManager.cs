using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//pulls info from card fucntions and Stores the game objects in a list

public class DeckEventManager : MonoBehaviour
{
    public static DeckEventManager instance;
    public List<GameObject> playerDeck1 = new List<GameObject>(11);
    public List<int> pId;
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

    public void AddButtonPressed(int pId)
    {
        if (onAddButtonPress != null)
        {
            onAddButtonPress(pId);



        }
    }
    public event Action<int> onRemoveButtonPress;
    public void RemoveButtonPressed(int pId)
    {
        if (onRemoveButtonPress != null)
        {
            onRemoveButtonPress(pId);
        }
    }

    private void Start()
    {


    }

    public void OnSceneChange()
    {

        playerDeck1.Clear();
        if (pId.Count > 0)
        {
            foreach (int pId in pId)
            {

                for (int i = 0; i < deck.Count; i++)
                {
                    if (pId == deck[i].GetComponent<CardStats>().playerId && deck[i] != null)
                    {
                        playerDeck1.Add(deck[i]);
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
