using DG.Tweening;
using JetBrains.Annotations;
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

        gameScene = true;

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
    public bool gameScene;
    

    public int runs;
    public int playerRuns;
    public int opponentRuns;
    public int mScore;
    public int oppScore;

    public float resetTimer;

    public string typeOfPlayer;
    public string typeOfOpponent;


    public Transform[] playerCardPositions;
    public Transform[] opponentCardPositions;
    public List<GameObject> inHandOcards;
    public List<GameObject> inHandPcards;
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
    }


    void Update()
    {
        BackToPos();
        FullD();

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
                    GameObject card= Instantiate(cardPrefabsinResources[j].GetComponent<CardStats>().gameObject);
                    playerCards.Add(card);
                    foreach (var pcard in playerCards)
                    {
                        pcard.tag = "Player";
                    }
                    
                }
            }

        }
            for (int i = 0; i < playerCards.Count; i++)
            {
                playerCards[i].transform.SetParent(playerSlots[i].transform);
                playerCards[i].transform.DOLocalMove(Vector3.zero, 0.5f);
                playerCards[i].transform.DOScale(new Vector3(30f, 30f, 30f), 0.1f);
            }

        for (int i = 0; i < oppdeckCardsId.Count; i++)
        {
            
            for (int j = 0; j < cardPrefabsinResources.Length; j++)
            {
                if (oppdeckCardsId[i] == cardPrefabsinResources[j].GetComponent<CardStats>().playerId)
                {
                    GameObject card = Instantiate(cardPrefabsinResources[j].GetComponent<CardStats>().gameObject);
                     enemyCards.Add(card);
                    foreach(var ecard in enemyCards)
                    {
                        ecard.tag = "Enemy";
                    }

                }
            }

        }

        for (int i = 0; i < enemyCards.Count; i++)
        {
            enemyCards[i].transform.SetParent(enemySlots[i].transform);
            enemyCards[i].transform.DOLocalMove(Vector3.zero, 0.5f);
            enemyCards[i].transform.DOScale(new Vector3(30f, 30f, 30f), 0.1f);
            enemyCards[i].transform.DORotate(new Vector3(90f, 0f, 0f), 0.1f);
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

    // //Panel refrences
    // public GameObject PlayerPanel;
    // public GameObject EnemyPanel;

    // public void ClosePlayerPanel()
    // {
    //     PlayerPanel.SetActive(false);
    // }
    // public void CloseEnemyPanel()
    // {
    //     EnemyPanel.SetActive(false);
    // }

    void BackToPos()
    {
        if (!playerCardSelected && !Dragging.drag && playerCardStats != null)
        {
            for (int i = 0; i < inHandPcards.Count; i++)
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
            for (int i = 0; i < inHandOcards.Count; i++)
            {
                if (opponentCardStats.gameObject == inHandOcards[i])
                {
                    opponentCardStats.gameObject.transform.DOMove(opponentCardPositions[i].position, 0.5f).SetEase(Ease.Linear);
                    opponentCardStats = null;
                    break;
                }
            }
        }
    }


    void FullD()
    {
        for (int i = 0; i<playerCards.Count; i++)
        {
                if (GameManager.instance.inHandPcards.Count > 2)
                {
                    playerCards[i].gameObject.GetComponent<CardStats>().AddButton.SetActive(false);
                }
                else
                    playerCards[i].gameObject.GetComponent<CardStats>().AddButton.SetActive(true);
        }
        
        for (int i = 0; i<enemyCards.Count; i++)
        {
            
            if (GameManager.instance.inHandOcards.Count > 2)
            {
                enemyCards[i].gameObject.GetComponent<CardStats>().AddButton.SetActive(false);
            }
            else
                enemyCards[i].gameObject.GetComponent<CardStats>().AddButton.SetActive(true);
        }

    }
    

}
