using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTest : MonoBehaviour
{
    



    // Update is called once per frame
    void Update()
    {
       SaveManager.Instance.State.PlayerDeck = Character.character.playerID;
       SaveManager.Instance.State.OpponentDeck = Character.character.enemyID;
        
    }

    public void Touch()
    {
        SaveManager.Instance.Save();
        Debug.Log("GameSaved");       

    }

    public void TouchLoad()
    {
        SaveManager.Instance.Load();
        Debug.Log("Game Loaded" + SaveManager.Instance.State.OpponentDeck[2]);
    }

}
