using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStats : MonoBehaviour
{
   

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
                GameManager.instance.playerRuns = playerStats.ball1;
                break;
            case 2:
                GameManager.instance.playerRuns = playerStats.ball2;
                break;
            case 3:
                GameManager.instance.playerRuns = playerStats.ball3;
                break;
            case 4:
                GameManager.instance.playerRuns = playerStats.ball4;
                break;
            case 5:
                GameManager.instance.playerRuns = playerStats.ball5;
                break;
            case 6:
                GameManager.instance.playerRuns = playerStats.ball6;
                break;
        }
    }
}
