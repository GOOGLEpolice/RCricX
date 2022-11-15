using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMode : MonoBehaviour
{
    public void CalculateSetScore()
    {
        if (GameManager.instance.opponentRuns < 0 && GameManager.instance.typeOfPlayer == "Batsman")
        {
            GameManager.instance.playerCardStats.gameObject.transform.DOShakeRotation(1f,20f,50,80f,false).OnComplete(() =>
            {
            GameManager.instance.playerCardStats.gameObject.transform.DOScale(Vector3.zero, 0.5f).OnComplete(() => { GameManager.instance.opponentCardSelected = false; Destroy(GameManager.instance.playerCardStats.gameObject); GameManager.instance.playerCardSelected = false; });
            
                });
            return;
        }


        if (GameManager.instance.playerRuns < 0 && GameManager.instance.typeOfOpponent == "Batsman")
        {
            GameManager.instance.opponentCardStats.gameObject.transform.DOShakeRotation(1f, 20f, 50, 80f, false).OnComplete(() =>
            {
                GameManager.instance.opponentCardStats.gameObject.transform.DOScale(Vector3.zero, 0.5f).OnComplete(() => { GameManager.instance.playerCardSelected = false; Destroy(GameManager.instance.opponentCardStats.gameObject); GameManager.instance.opponentCardSelected = false; });

            });
            return;
        }

        
        if (GameManager.instance.opponentRuns < 0 && GameManager.instance.typeOfPlayer == "Bowler" && GameManager.instance.playerRuns > 0)
        {
            GameManager.instance.oppScore = GameManager.instance.oppScore - GameManager.instance.playerRuns;
            GameManager.instance.playerCardSelected = false;
            GameManager.instance.opponentCardSelected = false;
            return;
        }

        if (GameManager.instance.playerRuns < 0 && GameManager.instance.typeOfOpponent == "Bowler" && GameManager.instance.opponentRuns > 0)
        {
            GameManager.instance.mScore = GameManager.instance.mScore - GameManager.instance.opponentRuns;
            GameManager.instance.playerCardSelected = false;
            GameManager.instance.opponentCardSelected = false;
            return;
        }

        if (GameManager.instance.playerRuns < 0 && GameManager.instance.opponentRuns < 0)
        {
            GameManager.instance.playerCardSelected = false;
            GameManager.instance.opponentCardSelected = false;
            return;
        }
       

        if (GameManager.instance.playerCardStats.gameObject.tag == "Player" && GameManager.instance.playerCardStats != null)
        {
                if (GameManager.instance.typeOfPlayer == "Bowler")
                {
                    GameManager.instance.oppScore = GameManager.instance.oppScore - GameManager.instance.playerRuns;
                }
                else if (GameManager.instance.typeOfPlayer == "Batsman")
                {
                    GameManager.instance.mScore = GameManager.instance.mScore + GameManager.instance.playerRuns;
                }
            GameManager.instance.playerCardSelected = false;
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
            GameManager.instance.opponentCardSelected = false;
        }
    }

}
