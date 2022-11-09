using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Singleton
    public static GameManager instance;

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);


            return;
        }

        inHandPcards = GameObject.FindGameObjectsWithTag("Player");
        inHandOcards = GameObject.FindGameObjectsWithTag("Enemy");


        for (int i = 0; i < playerCardPositions.Length; i++)
        {
            inHandPcards[i].transform.DOMove(playerCardPositions[i].position, 0.5f);
        }


        for (int i = 0; i < opponendCardPositions.Length; i++)
        {
            inHandOcards[i].transform.DOMove(opponendCardPositions[i].position, 0.5f);
        }

        instance = this;         
    }
    #endregion;

    SetMode setMode;
    public CardStats playerCardStats;
    public CardStats opponentCardStats;
    public bool set;                                                            //type of game mode
    public bool chase;                                                          //type of game mode
    public bool playerCardSelected;
    public bool opponentCardSelected;
    public bool playerReady;
    public bool opponentReady;
    public bool readyToCalculate;
    public bool scoreCalculated;
    public int runs;
    public int playerRuns;
    public int opponentRuns;
    public int mScore;
    public int oppScore;
    public float resetTimer;
    public string typeOfPlayer;
    public string typeOfOpponent;
    public Transform[] playerCardPositions;
    public Transform[] opponendCardPositions;
    public GameObject[] inHandOcards;
    public GameObject[] inHandPcards;

    void Update()
    {
        BackToPos();
        if (mScore < 0 || oppScore < 0)
        {
            mScore = 0;
            oppScore = 0;
        }
        
        if (playerReady && opponentReady)
        {
            readyToCalculate = true;
            SetGameMode();
        }
        
        if (scoreCalculated)
        {
            resetTimer += 1 * Time.deltaTime;
            if (resetTimer > 0.8f)
            {
                scoreCalculated = false;
                resetTimer = 0;
            }
        }
    }

    public void SetGameMode()
    {
        if (set)
        {
            setMode = gameObject.GetComponent<SetMode>();
            if (readyToCalculate)
            {
                setMode.CalculateSetScore();
                playerCardStats.IncreaseBallCount();
                opponentCardStats.IncreaseBallCount();
                scoreCalculated = true;
                AllFalse();
            }
        }
    }

    public void AllFalse()
    {
        playerReady = false;
        opponentReady = false;
        readyToCalculate = false;
    }

    void BackToPos()
    {
        if (!playerCardSelected && !Dragging.drag && playerCardStats != null)
        {
            for (int i = 0; i < inHandPcards.Length; i++)
            {
                Debug.Log("Executing");
                if (playerCardStats.gameObject == inHandPcards[i]) 
                {
                    playerCardStats.gameObject.transform.DOMove(playerCardPositions[i].position, 0.5f).SetEase(Ease.Linear);
                    playerCardStats = null;
                    break;
                }
            }
        }

        if (!opponentCardSelected && !Dragging.drag && opponentCardStats != null)
        {
            for (int i = 0; i < inHandOcards.Length; i++)
            {
                if (opponentCardStats.gameObject == inHandOcards[i])
                {
                    opponentCardStats.gameObject.transform.DOMove(opponendCardPositions[i].position, 0.5f).SetEase(Ease.Linear);
                    opponentCardStats = null;
                    break;
                }
            }
        }
    }
}
