using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStats : MonoBehaviour
{
   

    public PlayerStats playerStats;
    public Vector3 startPos;
    
    
    public int playerTurnCount;

    private void OnEnable()
    {
        startPos = transform.position;
    }
    void Start()
    {
        playerStats.playerBC = 0;
        
    }

    void Update()
    {
        
    }

    public void SwitchCases()
    {
        switch (playerStats.playerBC)
        {
            case 1:
                GameManager.instance.runs = playerStats.ball1;
                break;
            case 2:
                GameManager.instance.runs = playerStats.ball2;
                break;
            case 3:
                GameManager.instance.runs = playerStats.ball3;
                break;
            case 4:
                GameManager.instance.runs = playerStats.ball4;
                break;
            case 5:
                GameManager.instance.runs = playerStats.ball5;
                break;
            case 6:
                GameManager.instance.runs = playerStats.ball6;
                break;
        }
    }

    public void IncreaseBallCount()
    {
        playerStats.playerBC += 1;
        SwitchCases();
    }
}
