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
    public bool set;                                                            //type of game mode
    public bool chase;                                                          //type of game mode
    public bool playerCardSelected;
    public bool opponentCardSelected;
    public bool playerReady;
    public bool opponentReady;
    public bool readyToCalculate;
    public bool scoreCalculated;
    public int runs;
    public int playerRuns;
    public int opponentRuns;
    public int mScore;
    public int oppScore;
    public float resetTimer;
    public string typeOfPlayer;
    public string typeOfOpponent;
    
    
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
            SetGameMode();
        }
        
        if (scoreCalculated)
        {
            resetTimer += 1 * Time.deltaTime;
            if (resetTimer > 0.8f)
            {
                scoreCalculated = false;
                resetTimer = 0;
            }
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
                scoreCalculated = true;
                AllFalse();
            }
        }
    }

    void AllFalse()
    {
        playerReady = false;
        opponentReady = false;
        readyToCalculate = false;
    }
}
