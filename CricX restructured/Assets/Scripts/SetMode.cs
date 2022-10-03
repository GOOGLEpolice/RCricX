using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMode : MonoBehaviour
{
    
    public CardStats cardStats;
    public string typeOfPlayer;
    
    

    
    void Update()
    {
        
    }

    public void CalculateSetScore()
    {
            if (gameObject.tag == "Player")
            {

                if (GameManager.instance.typeOfPlayer == "Batsman")
                {
                    GameManager.instance.mScore = GameManager.instance.mScore + GameManager.instance.playerRuns;
                }
                else if (GameManager.instance.typeOfPlayer == "Bowler")
                {
                    GameManager.instance.mScore = GameManager.instance.oppScore - GameManager.instance.playerRuns;
                }
            }

            if (gameObject.tag == "Enemy")
            {

                if (GameManager.instance.typeOfPlayer == "Batsman")
                {
                    GameManager.instance.oppScore = GameManager.instance.oppScore + GameManager.instance.playerRuns;
                }
                else if (GameManager.instance.typeOfPlayer == "Bowler")
                {
                    GameManager.instance.mScore = GameManager.instance.mScore - GameManager.instance.playerRuns;
                }
            }
        
    }

}
