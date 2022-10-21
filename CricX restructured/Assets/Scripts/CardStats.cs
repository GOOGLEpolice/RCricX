using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardStats : MonoBehaviour
{
    public PlayerStats playerStats;
    public Vector3 startPos;
    public TMP_Text ballOne;
    public TMP_Text ballTwo;
    public TMP_Text ballThree;
    public TMP_Text ballFour;
    public TMP_Text ballFive;
    public TMP_Text ballSix;
    float destroyTimer;


    private void Awake()
    {
        /*ballOne = GetComponentInChildren<TMP_Text>();
        ballTwo = GetComponentInChildren<TMP_Text>();
        ballThree = GetComponentInChildren<TMP_Text>();
        ballFour = GetComponentInChildren<TMP_Text>();
        ballFive = GetComponentInChildren<TMP_Text>();
        ballSix = GetComponentInChildren<TMP_Text>();*/
        ShowText();
        
    }

    private void OnEnable()
    {
        startPos = transform.position;
    }
    void Start()
    {
        playerStats.playerBC = 1;
        //ShowText();
    }

    private void Update()
    {

        BackToPos();

        if (playerStats.playerBC > 6 && GameManager.instance.scoreCalculated)
        {
            destroyTimer += 1 * Time.deltaTime;
            AllTurnsPlayed();
        }

    }
    public void SwitchCases()
    {
        switch (playerStats.playerBC)
        {
            case 1:
                GameManager.instance.runs = playerStats.ball1;
                break;
            case 2:
                GameManager.instance.runs = playerStats.ball2;
                break;
            case 3:
                GameManager.instance.runs = playerStats.ball3;
                break;
            case 4:
                GameManager.instance.runs = playerStats.ball4;
                break;
            case 5:
                GameManager.instance.runs = playerStats.ball5;
                break;
            case 6:
                GameManager.instance.runs = playerStats.ball6;
                break;
        }
    }

    public void IncreaseBallCount()
    {
        playerStats.playerBC += 1;
    }

    void BackToPos()
    {
        if (!GameManager.instance.playerCardSelected && !Dragging.drag && GameManager.instance.playerCardStats != null)
        {
            transform.position = startPos;
            GameManager.instance.playerCardStats.gameObject.transform.position = GameManager.instance.playerCardStats.startPos;
            GameManager.instance.playerCardStats = null;
        }

        if (!GameManager.instance.opponentCardSelected && !Dragging.drag && GameManager.instance.opponentCardStats != null)
        {
            GameManager.instance.opponentCardStats.gameObject.transform.position = GameManager.instance.opponentCardStats.startPos;
            GameManager.instance.opponentCardStats = null;
        }
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
        ballOne.text = playerStats.ball1.ToString();
        ballTwo.text = playerStats.ball2.ToString();
        ballThree.text = playerStats.ball3.ToString();
        ballFour.text = playerStats.ball4.ToString();
        ballFive.text = playerStats.ball5.ToString();
        ballSix.text = playerStats.ball6.ToString();
    }
}
