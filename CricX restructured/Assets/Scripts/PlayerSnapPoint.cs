using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerSnapPoint : MonoBehaviour
{
    public GameObject playerReady;
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.localPosition = this.transform.localPosition;
            GameManager.instance.playerCardSelected = true;
            if (GameManager.instance.playerReady)
            {
                playerReady.SetActive(false);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.playerCardStats = other.gameObject.GetComponent<CardStats>();
            playerReady.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.playerCardSelected = false;
            playerReady.SetActive(false);
        }
    }

    public void OnReady()
    {
        GameManager.instance.playerCardStats.IncreaseBallCount();
        GameManager.instance.playerReady = true;
        GameManager.instance.playerRuns = GameManager.instance.runs;
        GameManager.instance.typeOfPlayer = GameManager.instance.playerCardStats.playerStats.PlayerType;
    }
}
