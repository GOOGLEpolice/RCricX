using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Spawns all prefabs with PCard tag in resources folder in the empty slots. 

public class PlayerCardCollection : MonoBehaviour
{
    public static PlayerCardCollection Instance; //singleton
    

    public List<GameObject> playerCardList = new List<GameObject>();
    

    public Transform[] Spawnpoints;
   
    

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {  
        playerCardList = new List<GameObject>(Resources.LoadAll<GameObject>("Prefabs"));
        SpawnCards();
        
    }
    
   public void SpawnCards()
    {
        DeckEventManager.instance.deck.Clear();
        for (int i = 0; i< playerCardList.Count;)
        {  
            for(int j = 0; j < Spawnpoints.Length;j++)
            {
                GameObject card = Instantiate(playerCardList[i],Spawnpoints[j].position,playerCardList[i].transform.localRotation);
                card.transform.SetParent(Spawnpoints[j].transform);
                DeckEventManager.instance.deck.Add(card);
                i++;


            }                   
        }
    }
}
