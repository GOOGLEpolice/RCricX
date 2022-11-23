using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InvSceneManager : MonoBehaviour
{
   public void GoToPlayerDeck()
    {
        SceneManager.LoadScene("DeckScreen");
    }

    public void GoToOppDeck()
    {
        SceneManager.LoadScene("OpDeckScreen");
      
    }

    private void Start()
    {
        /*DontDestroyOnLoad();*/
    }

}
