using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class InstanceManager : MonoBehaviour
{


    public float musicValue;


    public static InstanceManager instance;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;

            Load();


            DontDestroyOnLoad(this);
        }
        else
        {

            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Create);

        PlayerData data = new PlayerData();

        //data. Sound level = sound level



        data.musicValue = musicValue;

        Debug.Log("saved");
        bf.Serialize(file, data);
        file.Close();

    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);

            //sound level = data. sound level
            musicValue = data.musicValue;

        }
    }
}

[Serializable]
class PlayerData
{

    public float musicValue;
    //things to store
    //public int highscore
}
