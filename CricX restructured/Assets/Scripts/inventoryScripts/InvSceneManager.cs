using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InvSceneManager : MonoBehaviour
{
   public void GoToPlayerDeck()
    {
        SceneManager.LoadScene(1);
        OppDeckEventManager.instance.deckScene = true;
    }

    public void GoToOppDeck()
    {
        //SaveManager.Instance.PlayerSave();
        SceneManager.LoadScene(2);
        OppDeckEventManager.instance.deckScene = true;
    }

    public void GoToGameScene()
    {
        //SaveManager.Instance.EnemySave();
        SceneManager.LoadScene(3);
        OppDeckEventManager.instance.deckScene = false;
        GameManager.instance.gameScene = true;
    }
}
