using System.Collections;
using System.Collections.Generic;
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
            GameManager.instance.cardStats = other.gameObject.GetComponent<CardStats>();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.localPosition = playerCards.playerCardPositions[playerCards.playerCardPositions.Count];
        }
    }
}
