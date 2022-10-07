using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMode : MonoBehaviour
{
    
    //public CardStats cardStats;
    //public string typeOfPlayer;
    
    

    
    void Update()
    {
        
    }

    

    public void CalculateSetScore()
    {
        if (GameManager.instance.opponentRuns < 0 && GameManager.instance.typeOfPlayer == "Batsman")
        {
            GameManager.instance.playerCardStats.gameObject.SetActive(false);
            GameManager.instance.playerCardStats = null;
            
            return;
        }

        if (GameManager.instance.playerRuns < 0 && GameManager.instance.typeOfOpponent == "Batsman")
        {
            GameManager.instance.opponentCardStats.gameObject.SetActive(false);
            GameManager.instance.opponentCardStats = null;
            
            return;
        }

       

        if (GameManager.instance.playerCardStats.gameObject.tag == "Player" && GameManager.instance.playerCardStats != null)
        {
                if (GameManager.instance.typeOfPlayer == "Bowler")
                {
                    GameManager.instance.mScore = GameManager.instance.oppScore - GameManager.instance.playerRuns;
                }
                else if (GameManager.instance.typeOfPlayer == "Batsman")
                {
                    GameManager.instance.mScore = GameManager.instance.mScore + GameManager.instance.playerRuns;
                }
            
        }

            if (GameManager.instance.opponentCardStats.gameObject.tag == "Enemy" && GameManager.instance.opponentCardStats != null)
            {
                if (GameManager.instance.typeOfOpponent == "Bowler")
                {
                    GameManager.instance.mScore = GameManager.instance.mScore - GameManager.instance.opponentRuns;
                }

                else if (GameManager.instance.typeOfOpponent == "Batsman")
                {
                    GameManager.instance.oppScore = GameManager.instance.oppScore + GameManager.instance.opponentRuns;
                }
            
        }
    }

}
