using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentSnapPoint : MonoBehaviour
{

    public GameObject opponentReady;
    public GameObject oppLockIcon;
    public GameObject oppTickMark;

    public void newRound()
    {
        oppLockIcon.SetActive(false);
        opponentReady.SetActive(false);
        oppTickMark.SetActive(false);
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.transform.localPosition = this.transform.localPosition;
        }

        if (GameManager.instance.opponentReady)
        {
            opponentReady.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.opponentCardSelected = true;
        if (other.gameObject.tag == "Enemy")
        {
            GameManager.instance.opponentCardStats = other.gameObject.GetComponent<CardStats>();
            opponentReady.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GameManager.instance.opponentCardSelected = false;
            opponentReady.SetActive(false);
        }
    }

    public void OnReady()
    {
        oppLockIcon.SetActive(true);
        oppTickMark.SetActive(true);
        opponentReady.SetActive(false);
        GameManager.instance.opponentReady = true;
        GameManager.instance.opponentCardStats.SwitchCases();
        GameManager.instance.opponentRuns = GameManager.instance.runs;
        GameManager.instance.typeOfOpponent = GameManager.instance.opponentCardStats.playerStats.playerType.ToString();
    }
}
