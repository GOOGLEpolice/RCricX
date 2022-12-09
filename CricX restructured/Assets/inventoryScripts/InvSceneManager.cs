using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InvSceneManager : MonoBehaviour
{
   public void GoToPlayerDeck()
    {
        SceneManager.LoadScene("PlayerDeck");
        OppDeckEventManager.instance.deckScene = true;
    }

    public void GoToOppDeck()
    {
        SceneManager.LoadScene("EnemyDeck");
       
        OppDeckEventManager.instance.deckScene = true;
    }

    public void GoToGameScene()
    {
        SceneManager.LoadScene("GameScene");
        OppDeckEventManager.instance.deckScene = false;
        GameManager.instance.gameScene = true;
    }
}
