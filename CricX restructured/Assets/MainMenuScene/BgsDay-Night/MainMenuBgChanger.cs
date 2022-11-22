using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuBgChanger : MonoBehaviour
{
    public GameObject Day;
    public GameObject Eve;
    public GameObject Night;

    public int time;

    void Start()
    {
        Debug.Log("" + System.DateTime.Now.Hour);
        time = System.DateTime.Now.Hour;
        Day.SetActive(false);
        Eve.SetActive(false);
        Night.SetActive(false);
    }
    private void Update()
    {
        switch (time)
        {
            case <=4:
                Night.SetActive(true);
                break;
            case <= 13:
                Day.SetActive(true);
                break;
            case <= 14:
                Eve.SetActive(true);
                break;
            case <= 24:
                Night.SetActive(true);
                break;
        }
        /*
        if (time <= 4||time>=0)
        {
            //Destroy(Day);
            //Destroy(Eve);
            Day.SetActive(false);
            Eve.SetActive(false);
            Night.SetActive(true);
        }
        if (time <= 15||time >=5)
        {
            //Destroy(Eve);
            //Destroy(Night);
            dae.enabled = true;
            //Day.SetActive(true);
            //Eve.SetActive(false);
            //Night.SetActive(false);
        }
        if (time <= 19||time>=16)
        {
            //Destroy(Day);
            //Destroy(Night);
            Day.SetActive(false);
            Eve.SetActive(true);
            Night.SetActive(false);
        }
        if (System.DateTime.Now.Hour<=24 )
        {
            Day.SetActive(false);
            Eve.SetActive(false);
            Night.SetActive(true);
        }*/
    }
}
