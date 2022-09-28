using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Singleton
    public static GameManager instance;
    public bool cardSelected;

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);


            return;
        }
        instance = this;
    }
    #endregion;

    
    public CardStats cardStats;
    public bool set;
    public bool chase;
    public int mScore;


    void Start()
    {

        
    }

    
    void Update()
    {
        
    }

    void SetScoreCalculation()
    {

    }

   

    
}
