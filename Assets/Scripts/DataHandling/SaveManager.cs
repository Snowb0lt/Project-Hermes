using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public static string directory = "/SaveData/";
    public static string fileName = "PlayerData.txt";

    public static void Save(PlayerData playerData)
    {
        string dir = Application.persistentDataPath + directory;
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText(dir + fileName, json);
    }

    public static PlayerData Load()
    {
        string fullPath = Application.persistentDataPath + directory + fileName;
        PlayerData playerData = new PlayerData();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            playerData = JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            Debug.LogError("Save does not exist");
        }

        return playerData;
    }
}
