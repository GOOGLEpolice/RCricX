using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtManager : MonoBehaviour
{
    public GameObject setPan;
    public GameObject buttPan;
    public bool SFX;
    public bool Music;
     public void OnPlay()
    {
        SceneManager.LoadScene(sceneName: "GameScene");
    }

    public void OnInven()
    {
        SceneManager.LoadScene(sceneName: "PlayerDeck");
    }

    public void OnQuit()
    {
        Application.Quit(0);
    }

    public void OnSetting()
    {
        setPan.SetActive(true);
        buttPan.SetActive(false);
    }

    public void OnSetClose()
    {
        setPan.SetActive(false);
        buttPan.SetActive(true);
    }

    public void OnSFX()
    {
        //SFX toggle code goes here
        SFX = !SFX;
        
    }

    public void OnMusic()
    {
        //Music toggle code goes here
        Music = !Music;
    }
}
