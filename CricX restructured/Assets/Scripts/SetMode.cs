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

        }

        if (GameManager.instance.set)
        {

        }
    }

}
