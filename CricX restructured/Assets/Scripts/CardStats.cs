using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardStats : MonoBehaviour
{
    public PlayerStats playerStats;
    public int playerId;
    public Vector3 startPos;
    public GameObject playerModel;
    public TMP_Text cardName;
    public TMP_Text ballOne;
    public TMP_Text ballTwo;
    public TMP_Text ballThree;
    public TMP_Text ballFour;
    public TMP_Text ballFive;
    public TMP_Text ballSix;
    public TMP_Text[] balls = new TMP_Text[6];
    public Image ballImage;
    public Image batImage;
    float destroyTimer;

    
    bool Add;
    bool Remove;

    SlotsManager slotsManager;


    public GameObject AddButton;
    public GameObject RemoveButton;

    private void Awake()
    {
        ShowText();
    }
    
    void Start()
    {
        playerStats.playerBC = 1;
        AddToArray();
        OppDeckEventManager.instance.onAddButtonPress += AddToDeck;
        OppDeckEventManager.instance.onRemoveButtonPress += RemoveFromDeck;
        RemoveButton.SetActive(false);
    }

    private void Update()
    {

        if (playerStats.playerBC > 6 && GameManager.instance.scoreCalculated)
        {
            destroyTimer += 1 * Time.deltaTime;
            AllTurnsPlayed();
        }

        DeckFull();

    }
    public void SwitchCases()
    {
        switch (playerStats.playerBC)
        {
            case 1:
                GameManager.instance.runs = playerStats.ball1;
                ballOne.gameObject.SetActive(true);
                break;
            case 2:
                GameManager.instance.runs = playerStats.ball2;
                ballTwo.gameObject.SetActive(true);
                break;
            case 3:
                GameManager.instance.runs = playerStats.ball3; 
                ballThree.gameObject.SetActive(true);
                break;
            case 4:
                GameManager.instance.runs = playerStats.ball4;
                ballFour.gameObject.SetActive(true);
                break;
            case 5:
                GameManager.instance.runs = playerStats.ball5;
                ballFive.gameObject.SetActive(true);
                break;
            case 6:
                GameManager.instance.runs = playerStats.ball6;
                ballSix.gameObject.SetActive(true);
                break;
            case 7:
                Destroy(gameObject);
                break;
        }
    }

    public void IncreaseBallCount()
    {
        playerStats.playerBC += 1;
    }

    public void AllTurnsPlayed()
    {
        if (destroyTimer >= 0.5f)
        {
            Destroy(gameObject);
            destroyTimer = 0;
        }
    }

   

    public void ShowText()
    {
        cardName.text = playerStats.playerName;

        if (playerStats.ball1 < 0)
        {
            ballOne.text = "w".ToString();
        }
        else
            ballOne.text = playerStats.ball1.ToString();

        if (playerStats.ball2 < 0)
        {
            ballTwo.text = "w".ToString();
        }
        else
        {
            ballTwo.text = playerStats.ball2.ToString();
        }

        if (playerStats.ball3 < 0)
        {
            ballThree.text = "w".ToString();
        }
        else
            ballThree.text = playerStats.ball3.ToString();

        if (playerStats.ball4 < 0)
        {
            ballFour.text = "w".ToString();
        }
        else
            ballFour.text = playerStats.ball4.ToString();

        if (playerStats.ball5 < 0)
        {
            ballFive.text = "w".ToString();
        }
        else
            ballFive.text = playerStats.ball5.ToString();

        if (playerStats.ball6 < 0)
        {
            ballSix.text = "w".ToString();
        }
        else
            ballSix.text = playerStats.ball6.ToString();
        
    }

    public void AddToArray()
    {
        TextMeshProUGUI[] textObjects = gameObject.GetComponentsInChildren<TextMeshProUGUI>();
        for (int i = 0; i < balls.Length; i++)
        {
            balls[i] = textObjects[i];
        }
    }

    public void RemoveStats()
    {
        for (int i = 0; i < playerStats.playerBC - 1; i++)
        {
            balls[i].gameObject.SetActive(false);
        }
    }

    public void AddToDeck(int id)
    {
        if (id == this.playerId)
        {
            if (gameObject.tag == "Player")
            {
                OppDeckEventManager.instance.pid.Add(id);
            }

            if (gameObject.tag == "Enemy")
            {
                OppDeckEventManager.instance.oppId.Add(id);
            }

            if (OppDeckEventManager.instance.deckScene == true)
            {

                OppDeckEventManager.instance.opponentDeck1.Add(gameObject);


                AddButton.SetActive(false);
                Add = false;

                if (Add == false)
                {
                    RemoveButton.SetActive(true);
                }

                else if (Add == true)
                {
                    RemoveButton.SetActive(false);
                }

                gameObject.GetComponentInParent<OppSlotsManager>().childCard = null;

                foreach (Transform slots in OppDeckEventManager.instance.DeckSlots)
                {
                    for (int i = 0; i < OppDeckEventManager.instance.opponentDeck1.Count; i++)
                    {
                        if (OppDeckEventManager.instance.DeckSlots[i].gameObject.GetComponent<OppSlotsManager>().childCard != null)
                        {
                            i++;
                        }
                        if (OppDeckEventManager.instance.DeckSlots[i].gameObject.GetComponent<OppSlotsManager>().childCard == null)
                        {
                            gameObject.transform.SetParent(OppDeckEventManager.instance.DeckSlots[i]);
                            gameObject.transform.localPosition = Vector3.zero;
                        }
                    }

                }
            }

            if (GameManager.instance.gameScene == true)
            {
                RemoveButton.SetActive(false);

                if (gameObject.tag == "Player")
                {
                    GameManager.instance.inHandPcards.Add(gameObject);
                    for (int i = 0; i < GameManager.instance.playerCardPositions.Length;)
                    {
                        if (GameManager.instance.playerCardPositions[i].GetComponent<SlotManager>().card != null)
                        {
                            i++;
                        }

                        else if (GameManager.instance.playerCardPositions[i].GetComponent<SlotManager>().card == null)
                        {
                            GameManager.instance.inHandPcards[i].gameObject.transform.SetParent(GameManager.instance.playerCardPositions[i].transform);
                            GameManager.instance.inHandPcards[i].gameObject.transform.DOLocalMove(GameManager.instance.playerCardPositions[i].transform.position, 0.5f).SetEase(Ease.Linear);
                            GameManager.instance.playerCardPositions[i].GetComponent<SlotManager>().card = GameManager.instance.inHandPcards[i].gameObject;
                        }
                    }

                }
                
                if (gameObject.tag == "Enemy")
                {
                    GameManager.instance.inHandOcards.Add(gameObject);
                    for (int i = 0; i < GameManager.instance.opponentCardPositions.Length;)
                    {
                        if (GameManager.instance.opponentCardPositions[i].GetComponent<SlotManager>().card != null)
                        {
                            i++;
                        }

                        else if (GameManager.instance.opponentCardPositions[i].GetComponent<SlotManager>().card == null)
                        {
                            gameObject.transform.SetParent(GameManager.instance.opponentCardPositions[i].transform);
                            gameObject.transform.DOLocalMove(GameManager.instance.opponentCardPositions[i].transform.position, 0.5f).SetEase(Ease.Linear);
                            GameManager.instance.opponentCardPositions[i].GetComponent<SlotManager>().card = GameManager.instance.inHandOcards[i].gameObject;
                        }
                    }
                }
            }
        }
       
    }

    public void RemoveFromDeck(int id)
    {
        if (id == this.playerId)
        {
            if (OppDeckEventManager.instance.deckScene == true)
            {
                OppDeckEventManager.instance.opponentDeck1.Remove(gameObject);
                RemoveButton.SetActive(false);
                Remove = false;

                if (Remove == false)
                {
                    AddButton.SetActive(true);
                }

                else if (Remove == true)
                {
                    AddButton.SetActive(false);
                }
                gameObject.GetComponentInParent<OppSlotsManager>().childCard = null;

                for (int i = 0; i < OppDeckEventManager.instance.SpawnSlots.Count; i++)
                {
                    if (OppDeckEventManager.instance.SpawnSlots[i].gameObject.GetComponent<OppSlotsManager>().childCard != null)
                    {
                        i++;
                    }
                    if (OppDeckEventManager.instance.SpawnSlots[i].gameObject.GetComponent<OppSlotsManager>().childCard == null)
                    {
                        gameObject.transform.SetParent(OppDeckEventManager.instance.SpawnSlots[i]);
                        gameObject.transform.localPosition = Vector3.zero;
                    }
                }
            }
        }
    }

    public void DeckFull()
    {
        

        if (OppDeckEventManager.instance.opponentDeck1.Count > 10)
        {
            
            AddButton.SetActive(false);
        }

        else
        {
            
            AddButton.SetActive(true);
        }
    }

}
