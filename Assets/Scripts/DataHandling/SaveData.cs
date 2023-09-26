using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    private PlayerData playerData;
    // Start is called before the first frame update
    void Start()
    {
        playerData = PlayerData._instance;
    }

    public void SavePlayerData()
    {
        SaveManager.Save(playerData);
    }

    public void LoadPlayerData()
    {
        playerData = SaveManager.Load();
    }
}
