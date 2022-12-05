using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{

    #region Singleton
    private static SaveManager instance;
    public static SaveManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SaveManager>();
                if (instance == null)
                {
                    instance = new GameObject("Spawned SaveManager", typeof(SaveManager)).GetComponent<SaveManager>();
                }
            }
            return instance;
        }
        set
        {
            instance = value;
        }
    }
    #endregion

    [SerializeField] string savefileName = "savedata.CricX";
    [SerializeField] string esavefileName = "opponentdata.CricX";
    [SerializeField]bool loadOnStart = true;
    BinaryFormatter formatter;

    

    private SaveState state;
    public SaveState State { get => state; set => state = value; }

    private EnemySaveState estate;
    public EnemySaveState EState { get => estate; set => estate = value; }

    void Start()
    {
        formatter = new BinaryFormatter();
        DontDestroyOnLoad(this.gameObject);

        if (loadOnStart) { PlayerLoad(); EnemyLoad(); }
    }

    public void PlayerSave()
    {
        if (state == null)
            state = new SaveState();

        state.LastSaveTime = DateTime.Now;

        var file = new FileStream(savefileName, FileMode.OpenOrCreate, FileAccess.Write);
        formatter.Serialize(file, state);
        file.Close();
    }

    public void EnemySave()
    {
        if (estate == null)
            estate = new EnemySaveState();

        var file = new FileStream(esavefileName, FileMode.OpenOrCreate, FileAccess.Write);
        formatter.Serialize(file, estate);
        file.Close();
    }

    public void PlayerLoad()
    {
        try
        {
            var file = new FileStream(savefileName, FileMode.Open, FileAccess.Read);
            state = (SaveState)formatter.Deserialize(file);
            file.Close();
        }
        catch
        {
            Debug.Log("No save file found, Creating a new entry!");
            PlayerSave();
        }

    }

    public void EnemyLoad()
    {
        try
        {
            var file = new FileStream(esavefileName, FileMode.Open, FileAccess.Read);
            estate = (EnemySaveState)formatter.Deserialize(file);
            file.Close();
        }
        catch
        {
            Debug.Log("No save file found, Creating a new entry!");
            EnemySave();
        }
    }
    
}
