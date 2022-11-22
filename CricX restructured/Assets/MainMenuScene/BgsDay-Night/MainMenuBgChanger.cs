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
    }
}
