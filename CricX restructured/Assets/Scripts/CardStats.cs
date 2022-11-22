using DG.Tweening;
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
       
        ShowText();
        
    }

    private void OnEnable()
    {
        playerStats.balls = new int[6];
    }
    void Start()
    {
        playerStats.playerBC = 1;
    }

    private void Update()
    {

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

    public void DecreaseBallCount()
    {
        playerStats.playerBC -= 1;
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
        if(playerStats.ball1 < 0){ ballOne.text = "Out".ToString(); }
        else
            ballOne.text = playerStats.ball1.ToString(); 

        if(playerStats.ball2 < 0){ ballTwo.text = "Out".ToString();}
        else 
            ballTwo.text = playerStats.ball2.ToString(); 
        
        if(playerStats.ball3 < 0){ ballThree.text = "Out".ToString();}
        else  
            ballThree.text = playerStats.ball3.ToString(); 

        if (playerStats.ball4 < 0){ballFour.text = "Out".ToString();}
        else
            ballFour.text = playerStats.ball4.ToString();
        
        if(playerStats.ball5 < 0){ ballFive.text = "Out".ToString(); }
        else
            ballFive.text = playerStats.ball5.ToString();

        if(playerStats.ball6 < 0) { ballSix.text = "Out".ToString();}
        else
            ballSix.text = playerStats.ball6.ToString();
    }
}
