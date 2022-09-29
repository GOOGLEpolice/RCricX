using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Singleton
    public static GameManager instance;
    public bool cardSelected;

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);


            return;
        }
        instance = this;
    }
    #endregion;

    SetMode setMode;
    public CardStats cardStats;
    public bool set;
    public bool chase;
    public bool playerReady;
    public bool oppReady;
    public int mScore;
    public int oppScore;
    


    void Start()
    {
        setMode = gameObject.GetComponent<SetMode>();
        
    }

    
    void Update()
    {
        StartCoroutine(SetGameMode());
    }

    IEnumerator SetGameMode()
    {
        if (playerReady && oppReady)
        {
            yield return null;
        }
    }
}
