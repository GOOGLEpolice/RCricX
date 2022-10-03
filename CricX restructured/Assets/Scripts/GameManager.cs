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
    public CardStats cardStats;
    public bool set;
    public bool chase;
    public bool cardSelected;
    public bool playerReady;
    public bool opponentReady;
    public bool readyToCalculate;
    public int playerRuns;
    public int mScore;
    public int oppScore;
    public string typeOfPlayer;
    
    
    void Start()
    {
        setMode = gameObject.GetComponent<SetMode>();
    }

    
    void Update()
    {
        if (mScore < 0 || oppScore < 0)
        {
            mScore = 0;
            oppScore = 0;
        }
        typeOfPlayer = cardStats.playerStats.PlayerType;
    }

    void SetGameMode()
    {
        if (set)
        {
            if (readyToCalculate)
            {
                setMode.CalculateSetScore();
            }
        }
    }


}
