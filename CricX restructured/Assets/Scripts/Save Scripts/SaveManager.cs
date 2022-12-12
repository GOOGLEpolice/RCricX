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

    [SerializeField] public string savefileName = "savedata.CricX";
    [SerializeField] public string esavefileName = "opponentdata.CricX";
    [SerializeField] public string filePath;
    [SerializeField] public string efilePath;
    BinaryFormatter formatter;

    

    
   

    

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        filePath = Application.persistentDataPath + "/saves/" + savefileName;
        efilePath = Application.persistentDataPath + "/esaves/" + esavefileName;
    }

    void Start()
    {
        formatter = new BinaryFormatter();
    }

    public void PlayerSave(object state)
    {
        


        if (!Directory.Exists(Application.persistentDataPath + "/saves"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves");
        }

        string path = filePath;

        FileStream file = File.Create(path);
        formatter.Serialize(file, state);
        file.Close();

        /* var file = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
         formatter.Serialize(file, state);
         file.Close();*/
    }

    public void EnemySave(object estate)
    {


        if (!Directory.Exists(Application.persistentDataPath + "/esaves"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/esaves");
        }

        string path = efilePath;

        FileStream file = File.Create(path);
        formatter.Serialize(file, estate);
        file.Close();

        /*var file = new FileStream(efilePath, FileMode.OpenOrCreate, FileAccess.Write);
        formatter.Serialize(file, estate);
        file.Close();*/
    }

    public static object PlayerLoad(string path)
    {
       
        if (!File.Exists(path))
        {
            Debug.Log("file doesnt exists");
            return null;
        }

        BinaryFormatter formatter = new BinaryFormatter();

        FileStream file = File.Open(path, FileMode.Open);

        try
        {
            object save = formatter.Deserialize(file);
            file.Close();
            
            return save;
        }
        catch
        {
            file.Close();
            return null;
        }

        /*if (Directory.Exists(Application.persistentDataPath + "/saves"))
        {
            var file = new FileStream(savefileName, FileMode.Open, FileAccess.Read);
            state = (SaveState)formatter.Deserialize(file);
            file.Close();
        }
        else
        {
            Debug.Log("No save file found, Creating a new entry!");
            PlayerSave();
        }*/

    }

    public static object EnemyLoad(string path)
    {

        if (!File.Exists(path))
        {
            return null;
        }

        BinaryFormatter formatter = new BinaryFormatter();

        FileStream file = File.Open(path, FileMode.Open);

        try
        {
            object save = formatter.Deserialize(file);
            file.Close();
            return save;
        }
        catch
        {
            file.Close();
            return null;
        }

        /*if (Directory.Exists(Application.persistentDataPath + "/saves"))
        {
            var file = new FileStream(esavefileName, FileMode.Open, FileAccess.Read);
            estate = (EnemySaveState)formatter.Deserialize(file);
            file.Close();
        }
        else
        {
            Debug.Log("No save file found, Creating a new entry!");
            EnemySave();
        }*/

    }
    
}
