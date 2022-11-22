using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Spawns all prefabs with PCard tag in resources folder in the empty slots. 

public class OppPlayerCardCollection : MonoBehaviour
{
    public static OppPlayerCardCollection Instance; //singleton
    

    public List<GameObject> playerCardList = new List<GameObject>();

    public Transform[] Spawnpoints;
   
    

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {  
        playerCardList = new List<GameObject>(Resources.LoadAll<GameObject>("OppPrefabs"));
        SpawnCards();
    }
    
   public void SpawnCards()
    {   
        for (int i = 0; i< playerCardList.Count;)
        {  
            for(int j = 0; j < Spawnpoints.Length;j++)
            {
                Instantiate(playerCardList[i],Spawnpoints[j].position,transform.localRotation);
                i++;
            }                   
        }
    }
}
