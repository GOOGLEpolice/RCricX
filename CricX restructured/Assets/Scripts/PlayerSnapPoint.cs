using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerSnapPoint : MonoBehaviour
{
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.localPosition = this.transform.localPosition;
            
            if (GameManager.instance.playerReady)
            {
                GameManager.instance.playerReadyIcon.SetActive(true);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.playerCardSelected = true;
            GameManager.instance.playerCardStats = other.gameObject.GetComponent<CardStats>();
            GameManager.instance.playerReadyIcon.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.playerCardSelected = false;
            GameManager.instance.newRoundPlayer();
        }
    }

    public void OnReady()
    {
        GameManager.instance.pLockIcon.SetActive(true);
        GameManager.instance.pTickMark.SetActive(true);
        GameManager.instance.playerReady = true;
        GameManager.instance.playerCardStats.SwitchCases();
        GameManager.instance.playerRuns = GameManager.instance.runs;
        GameManager.instance.typeOfPlayer = GameManager.instance.playerCardStats.playerStats.playerType.ToString();
    }

    public void OnUnready()
    {
        GameManager.instance.pLockIcon.SetActive(false);
        GameManager.instance.playerReadyIcon.SetActive(true);
    }
}
