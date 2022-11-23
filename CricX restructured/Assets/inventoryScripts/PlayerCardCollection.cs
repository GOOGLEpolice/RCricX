using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Spawns all prefabs with PCard tag in resources folder in the empty slots. 

public class PlayerCardCollection : MonoBehaviour
{
    public static PlayerCardCollection Instance; //singleton
    public float test = 99f;

    public List<GameObject> playerCardList = new List<GameObject>();

    public Transform[] Spawnpoints;
    public GameObject Prefab;
    public bool Sp1;
   
    

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
        Sp1 = false;
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
