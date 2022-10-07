using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Singleton
    public static GameManager instance;

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

    SetMode setMode;
    public CardStats playerCardStats;
    public CardStats opponentCardStats;
    //public PlayerCards playerCards;
    public bool set;
    public bool chase;
    public bool cardSelected;
    public bool playerReady;
    public bool opponentReady;
    public bool readyToCalculate;
    public int runs;
    public int playerRuns;
    public int opponentRuns;
    public int mScore;
    public int oppScore;
    public string typeOfPlayer;
    public string typeOfOpponent;
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (mScore < 0 || oppScore < 0)
        {
            mScore = 0;
            oppScore = 0;
        }
        
        if (playerReady && opponentReady)
        {
            readyToCalculate = true;
            //setScoreCalculator.SetActive(true);
            SetGameMode();
        }
    }

    public void SetGameMode()
    {
        if (set)
        {
            setMode = gameObject.GetComponent<SetMode>();
            if (readyToCalculate)
            {
                setMode.CalculateSetScore();
                playerReady = false;
                opponentReady = false;
                readyToCalculate=false;
            }
        }
    }

}
