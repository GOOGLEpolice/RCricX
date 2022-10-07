using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerSnapPoint : MonoBehaviour
{
    public PlayerCards playerCards;
    
    

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player Entered");
            other.transform.localPosition = this.transform.localPosition;
            GameManager.instance.playerCardStats = other.gameObject.GetComponent<CardStats>();
            GameManager.instance.cardSelected = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.playerCardStats = null;
            GameManager.instance.cardSelected = false;
            //GameManager.instance.playerCardStats.gameObject.transform.position = GameManager.instance.playerCardStats.playerCardPositions[0];
        }
    }

    public void OnReady()
    {
        GameManager.instance.playerCardStats.IncreaseBallCount();
        GameManager.instance.playerReady = true;
        GameManager.instance.playerRuns = GameManager.instance.runs;
        GameManager.instance.typeOfPlayer = GameManager.instance.playerCardStats.playerStats.PlayerType;
        //GameManager.instance.SetGameMode(cardStats.gameObject);
    }
}
