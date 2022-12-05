using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTest : MonoBehaviour
{
    



    // Update is called once per frame
    void Update()
    {
       SaveManager.Instance.State.PlayerDeck = Character.character.playerID;
       SaveManager.Instance.EState.OpponentDeck = Character.character.enemyID;
        
    }

    public void PlayerTouch()
    {
        SaveManager.Instance.PlayerSave();
    }

    public void EnemyTouch()
    {
        SaveManager.Instance.EnemySave();
    }

    public void TouchLoad()
    {
        SaveManager.Instance.PlayerLoad();
        SaveManager.Instance.EnemyLoad();
    }

}
