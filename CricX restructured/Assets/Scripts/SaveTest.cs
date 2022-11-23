using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTest : MonoBehaviour
{
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SaveManager.Instance.State.OpponentDeck = OppDeckEventManager.instance.opponentDeck1;
    }

    public void Touch()
    {
            SaveManager.Instance.Save();
            Debug.Log("GameSaved");       

    }

    public void TouchLoad()
    {

            SaveManager.Instance.Load();
            Debug.Log("Game Loaded");
    }
}
