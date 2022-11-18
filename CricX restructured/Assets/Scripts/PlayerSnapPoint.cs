using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerSnapPoint : MonoBehaviour
{
    public GameObject playerReady;
    public GameObject lockIcon;
    public GameObject tickMark;

    public void newRound()
    {
        lockIcon.SetActive(false);
        playerReady.SetActive(false);
        tickMark.SetActive(false);
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.localPosition = this.transform.localPosition;
            
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
            GameManager.instance.playerCardSelected = true;
            GameManager.instance.playerCardStats = other.gameObject.GetComponent<CardStats>();
            playerReady.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.playerCardSelected = false;
            newRound();
        }
    }

    public void OnReady()
    {
        lockIcon.SetActive(true);
        tickMark.SetActive(true);
        GameManager.instance.playerReady = true;
        GameManager.instance.playerCardStats.SwitchCases();
        GameManager.instance.playerRuns = GameManager.instance.runs;
        GameManager.instance.typeOfPlayer = GameManager.instance.playerCardStats.playerStats.playerType.ToString();
    }
}
