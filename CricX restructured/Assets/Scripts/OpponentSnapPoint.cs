using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentSnapPoint : MonoBehaviour
{
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Opponent Entered");
            other.transform.localPosition = this.transform.localPosition;
            GameManager.instance.opponentCardStats= other.gameObject.GetComponent<CardStats>();
            GameManager.instance.cardSelected = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GameManager.instance.opponentCardStats = null;
            GameManager.instance.cardSelected = false;
            //GameManager.instance.playerCardStats.gameObject.transform.position = GameManager.instance.playerCardStats.playerCardPositions[0];
        }
    }

    public void OnReady()
    {
        GameManager.instance.opponentCardStats.IncreaseBallCount();
        GameManager.instance.opponentReady = true;
        GameManager.instance.opponentRuns = GameManager.instance.runs;
        GameManager.instance.typeOfOpponent = GameManager.instance.opponentCardStats.playerStats.PlayerType;
        //GameManager.instance.SetGameMode(cardStats.gameObject);
    }
}
