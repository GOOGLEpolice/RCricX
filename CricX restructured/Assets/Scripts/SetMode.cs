using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMode : MonoBehaviour
{
    
    public CardStats cardStats;
    public string typeOfPlayer;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        typeOfPlayer = cardStats.playerStats.PlayerType;
    }

    public void CalculateSetScore()
    {
        if (GameManager.instance.set)
        {
            GameManager.instance.mScore = 0;
            if (cardStats.playerStats.PlayerType == "Batsman" && GameManager.instance.playerReady)
            {

            }
        }

        if (GameManager.instance.set)
        {
            GameManager.instance.oppScore = 0;

        }
    }

}
