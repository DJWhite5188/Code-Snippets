using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public  class SaveSystem
{
    private const string saveSystemVersion = "1_1";
    private static string saveFilePath = Application.persistentDataPath + "/savedGames" + saveSystemVersion + ".txt";

    public static Dictionary<string, PlayerData> savedGames = new Dictionary<string, PlayerData>();
    public static void Save()
    {
        if (PlayerData.current.profile == null)
        {
            return;
        }

        savedGames[PlayerData.current.profile] = PlayerData.current;
        SaveToDisk();
    }

    public static void SaveToDisk()
    {
        Debug.Log("Saved");
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(saveFilePath);
        Debug.Log(Application.persistentDataPath);
        bf.Serialize(file, SaveSystem.savedGames);
        file.Close();
    }

    public static void LoadList()
    {
        if (File.Exists(saveFilePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(saveFilePath, FileMode.Open);
            SaveSystem.savedGames = (Dictionary<string, PlayerData>)bf.Deserialize(file);
            file.Close();
        }
    }

    public static void SavePlayerDataList(List<PlayerData> playerDataList)
    {
        foreach(var playerData in playerDataList)
        {
            savedGames[playerData.profile] = playerData;
        }

        SaveToDisk();
    }

    public static void SelectPlayerData(string profile)
    {
        PlayerData.current = savedGames[profile];
    }

    public static void RemovePlayerData(string profile)
    {
        savedGames.Remove(profile);
        SaveToDisk();
    }

    public static void ResetAllPlayerData()
    {
        savedGames.Clear();
        SaveToDisk();
    }
}