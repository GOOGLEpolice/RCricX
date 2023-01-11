using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SaveTest : MonoBehaviour
{
    



    // Update is called once per frame
    void Update()
    {
       
        
    }

    public void PlayerTouch()
    {
       SaveState.state.PlayerDeck = OppDeckEventManager.instance.pid;
        SaveManager.Instance.PlayerSave(SaveState.state);
        //Debug.Log(SaveManager.Instance.State);
    }

    public void EnemyTouch()
    {
        EnemySaveState.estate.OpponentDeck = OppDeckEventManager.instance.oppId;
        SaveManager.Instance.EnemySave(EnemySaveState.estate);
    }

    public void TouchLoad()
    {
        //SaveManager.PlayerLoad(path: Application.persistentDataPath + "/saves" + SaveManager.Instance.savefileName);
        SaveManager.PlayerLoad(path: SaveManager.Instance.filePath);
        SaveManager.EnemyLoad(path: Application.persistentDataPath + "/esaves" + SaveManager.Instance.esavefileName);
    }

}
