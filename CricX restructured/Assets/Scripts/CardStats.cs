using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStats : MonoBehaviour
{
   /* #region Singleton
    public static CardStats instance;
    //public bool cardSelected;

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);


            return;
        }
        instance = this;
    }
    #endregion;*/

    public PlayerStats playerStats;

    void Start()
    {
        playerStats.playerBC = 0;
    }

    void Update()
    {
        
    }
}
