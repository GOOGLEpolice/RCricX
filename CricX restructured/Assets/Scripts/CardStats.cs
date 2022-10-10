using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStats : MonoBehaviour
{
    public PlayerStats playerStats;
    public Vector3 startPos;
    float destroyTimer;
    

    private void OnEnable()
    {
        startPos = transform.position;
    }
    void Start()
    {
        playerStats.playerBC = 0;
    }

    private void Update()
    {
        BackToPos();

        if (playerStats.playerBC >= 6 && GameManager.instance.scoreCalculated)
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
        SwitchCases();
        
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
}
