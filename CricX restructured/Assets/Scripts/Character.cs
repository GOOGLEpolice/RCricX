using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public static Character character;

    public List<int> playerID;
    public List<int> enemyID;

    private void Awake()
    {
        character = this;
        DontDestroyOnLoad(this.gameObject);
    }


    public void Update()
    {
        playerID = OppDeckEventManager.instance.pid;
        enemyID = OppDeckEventManager.instance.oppId;
    }



}
