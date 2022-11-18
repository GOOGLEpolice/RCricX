using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class timer : MonoBehaviour
{
    /* public float startTime;
     public float currentTime;*/

     //public bool timeStarted = false;

    public TMP_Text timerTxt;

    /*public GameObject calmTimer;
    public GameObject agroTimer;*/

    private void Awake()
    {
        //GameManager.instance.startTime = 36;
    }
    void Start()
    {
        GameManager.instance.timeStarted = true;
        GameManager.instance.startTime = 36;
        
        GameManager.instance.calmTimer.SetActive(true);
        GameManager.instance.agroTimer.SetActive(false);
    }

    public void TimerReset()
    {
        GameManager.instance.startTime = 36;
    }

    void Update()
    {
        timerTxt.text = GameManager.instance.startTime.ToString();
        if (GameManager.instance.timeStarted)
        {
            GameManager.instance.startTime -= Time.deltaTime;
            if (GameManager.instance.startTime <= 0)
            {
                Debug.Log("Time is up");
                GameManager.instance.timeStarted = false;
                GameManager.instance.startTime = 36;
                //currentTime = startTime;
            }
            if (GameManager.instance.startTime >= 10)
            {
                timerTxt.text = GameManager.instance.startTime.ToString("f0");
                GameManager.instance.calmTimer.SetActive(true);
                GameManager.instance.agroTimer.SetActive(false);
            }
            else
            {
                timerTxt.text = GameManager.instance.startTime.ToString("f1");
                GameManager.instance.agroTimer.SetActive(true);
                GameManager.instance.calmTimer.SetActive(false);
            }
        }
    }
}
