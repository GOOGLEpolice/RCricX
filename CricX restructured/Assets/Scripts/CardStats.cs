using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStats : MonoBehaviour
{
   /* #region Singleton
    public static CardStats instance;
    //public bool cardSelected;

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);


            return;
        }
        instance = this;
    }
    #endregion;*/

    public PlayerStats playerStats;
    public int playerTurnCount;

    void Start()
    {
        playerStats.playerBC = 0;
    }

    void Update()
    {
        
    }

    void SwitchCases()
    {
        switch (playerStats.playerBC)
        {
            case 1:
                playerTurnCount = playerStats.ball1;
                break;
            case 2:
                playerTurnCount = playerStats.ball2;
                break;
            case 3:
                playerTurnCount = playerStats.ball3;
                break;
            case 4:
                playerTurnCount = playerStats.ball4;
                break;
            case 5:
                playerTurnCount = playerStats.ball5;
                break;
            case 6:
                playerTurnCount = playerStats.ball6;
                break;
        }
    }
}
