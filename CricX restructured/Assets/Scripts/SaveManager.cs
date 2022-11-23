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
    [SerializeField]bool loadOnStart = true;
    BinaryFormatter formatter;

    private SaveState state;
    public SaveState State { get => state; set => state = value; }

    void Start()
    {
        formatter = new BinaryFormatter();
        DontDestroyOnLoad(this.gameObject);

        if (loadOnStart) { Load(); }
    }

    public void Save()
    {
        if (state == null)
            state = new SaveState();

        state.LastSaveTime = DateTime.Now;

        var file = new FileStream(savefileName, FileMode.OpenOrCreate, FileAccess.Write);
        formatter.Serialize(file, state);
        file.Close();
    }

    public void Load()
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
            Save();
        }

    }
    
}
