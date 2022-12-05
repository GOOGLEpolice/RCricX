using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
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


        /*for (int i = 0; i < playerCardPositions.Length; i++)
        {
            inHandPcards[i].transform.DOMove(playerCardPositions[i].position, 0.5f);
        }


        for (int i = 0; i < opponendCardPositions.Length; i++)
        {
            inHandOcards[i].transform.DOMove(opponendCardPositions[i].position, 0.5f);
        }*/



        instance = this;         
    }
    #endregion;

    SetMode setMode;

    //public CardStats cardStats;
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
    public List<int> pdeckCardsId;
    public List<int> oppdeckCardsId;

    public List<GameObject> playerCards;
    public List<GameObject> enemyCards;

    public Object[] cardPrefabsinResources;
    

    public List<Transform> playerSlots;
    public List<Transform> enemySlots;

    //public timer timer;

    public bool timeStarted = false;


    public float startTime;
    public float currentTime;

    public GameObject playerReadyIcon;
    public GameObject pLockIcon;
    public GameObject pTickMark;

    public GameObject opponentReadyIcon;
    public GameObject oppLockIcon;
    public GameObject oppTickMark;

    public GameObject calmTimer;
    public GameObject agroTimer;


    private void Start()
    {
        startTime = 36;
        SpawnCards();
        
        for (int i = 0; i < enemySlots.Count; i++)
        {
            GameObject.FindGameObjectsWithTag("Enemy")[i].transform.position = enemySlots[i].transform.position;
        }

    }


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
                playerCardStats.RemoveStats();
                opponentCardStats.RemoveStats();
                timeStarted = true;
                startTime = 36;
            }
        }
    }

    public void SpawnCards()
    {
        

        SaveManager.Instance.PlayerLoad();
        SaveManager.Instance.EnemyLoad();

        pdeckCardsId = SaveManager.Instance.State.PlayerDeck;

        oppdeckCardsId = SaveManager.Instance.EState.OpponentDeck;

        cardPrefabsinResources = Resources.LoadAll("Prefabs", typeof(GameObject));

        for (int i = 0; i < pdeckCardsId.Count; i++)
        {

            for (int j = 0; j < cardPrefabsinResources.Length; j++)
            {
                
                if (pdeckCardsId[i] == cardPrefabsinResources[j].GetComponent<CardStats>().playerId)
                {
                    Instantiate(cardPrefabsinResources[j].GetComponent<CardStats>().gameObject);
                    i++; j++;

                    foreach (var card in enemyCards)
                    {
                        card.tag = "Player";
                    }
                }
            }

        }

        for (int i = 0; i < oppdeckCardsId.Count; i++)
        {
            
            for (int j = 0; j < cardPrefabsinResources.Length; j++)
            {
                if (oppdeckCardsId[i] == cardPrefabsinResources[j].GetComponent<CardStats>().playerId)
                {
                    Instantiate(cardPrefabsinResources[j].GetComponent<CardStats>().gameObject);
                    foreach (var card in enemyCards)
                    {
                        card.tag = "Enemy";
                    }

                }
            }

        }
    }

    public void AllFalse()
    {
        playerReady = false;
        opponentReady = false;
        readyToCalculate = false;
    }

    public void newRoundPlayer()
    {
        pLockIcon.SetActive(false);
        pTickMark.SetActive(false);
        playerReadyIcon.SetActive(false);
    }

    public void newRoundOpponent()
    {
        oppLockIcon.SetActive(false);
        opponentReadyIcon.SetActive(false);
        oppTickMark.SetActive(false);
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
