using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class PlayerDataCtrl {

    private int stars;
    public PlayerData data;

    public  string stateMainMenu = "MAINMENU";
    public  string stateTutorial = "TUTORIAL";
    public  string stateLevel1 = "LEVEL1";
    public  string stateLevel2 = "LEVEL2";

    private string CurrentState{ get; set;}

    private static PlayerDataCtrl entity;

    private List<Level> levelList;

    public static PlayerDataCtrl Entity
    {
        get
        {
            if (entity == null)
            {
                entity = new PlayerDataCtrl();
            }
            return entity;
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/PlayerInfo.dat", FileMode.OpenOrCreate);

        if (data == null)
        {
            data = new PlayerData();
            data.tutorial = new Tutorial();
            data.level1 = new Level();
            data.level2 = new Level2();
        }

        switch (CurrentState)
        {
            case "TUTORIAL":
                {
                    data.tutorial.STARSGAINED = stars;
                    break;
                }
            case "LEVEL1":
                {
                    data.level1.STARSGAINED = stars;
                    break;
                }
            case "LEVEL2":
                {
                    data.level2.STARSGAINED = stars;
                    break;
                }
            default:
                {
                    break;
                }
        }

        bf.Serialize(file, data);
        file.Close();

        Debug.Log("Stars saved"+ data.level1.STARSGAINED);
    }

    public void ChangeState(string state)
    {
        CurrentState = state;
        stars = 0;
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/PlayerInfo.dat")){
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/PlayerInfo.dat", FileMode.Open);
            data = (PlayerData)bf.Deserialize(file);
            file.Close();

            Debug.Log("Stars loaded: " + data.level1.STARSGAINED);
        }
        else
        {
            data = new PlayerData();
            data.tutorial = new Tutorial();
            data.level1 = new Level();
            data.level2 = new Level2();
        }


    }

    public void AddStar()
    {
        stars++;
        Debug.Log("Stars " + stars);
    }

    [Serializable]
    public class PlayerData
    {
        public int deaths;
        public Level tutorial;
        public Level level1;
        public Level level2;

       
    }


}
