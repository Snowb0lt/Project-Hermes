using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    //Player Stats

    public int _coins;
    public int _dayNumber;
    public int _daysLeft;
    public int _longestDistance;

    //Player Upgrades


    //Instance
    private static PlayerData _instance;
    // Start is called before the first frame update
    public static PlayerData Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PlayerData();
            }
            return _instance;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
