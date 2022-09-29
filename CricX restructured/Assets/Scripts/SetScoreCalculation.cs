using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScoreCalculation : MonoBehaviour
{

    SetMode setMode;
    CardStats cardStats;

    void Start()
    {
        gameObject.GetComponent<SetMode>();
    }

    
    void Update()
    {
        cardStats = GameManager.instance.cardStats;
    }

    void SetCalculation()
    {
        if (cardStats.playerStats.PlayerType == "Batsman")
        {

        }
    }
}
