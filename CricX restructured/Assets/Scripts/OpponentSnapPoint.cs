using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentSnapPoint : MonoBehaviour
{
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.transform.localPosition = this.transform.localPosition;
        }

        if (GameManager.instance.opponentReady)
        {
            GameManager.instance.opponentReadyIcon.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.opponentCardSelected = true;
        if (other.gameObject.tag == "Enemy")
        {
            GameManager.instance.opponentCardStats = other.gameObject.GetComponent<CardStats>();
            GameManager.instance.opponentReadyIcon.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GameManager.instance.opponentCardSelected = false;
            GameManager.instance.newRoundOpponent();
        }
    }

    public void OnReady()
    {
        GameManager.instance.oppLockIcon.SetActive(true);
        GameManager.instance.oppTickMark.SetActive(true);
        GameManager.instance.opponentReady = true;
        GameManager.instance.opponentCardStats.SwitchCases();
        GameManager.instance.opponentRuns = GameManager.instance.runs;
        GameManager.instance.typeOfOpponent = GameManager.instance.opponentCardStats.playerStats.playerType.ToString();
    }
}
