using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Houses the player's stats and upgrades between scenes
/// </summary>


public class PlayerData : MonoBehaviour
{
    //Player Stats

    public int _coins;
    public int _dayNumber;
    public int _daysLeft;
    public int _longestDistance;

    //Player Upgrades
    public Dictionary<string, int> UpgradeDictionary = new Dictionary<string, int>()
    {
        //{"Increase Bounce", 0},
        //{"Increase Launcher Force", 0},
    };
    public int _launchForce;
    public int _PlayerBounce;

    //Instance
    public static PlayerData _instance;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
        Object.Destroy(gameObject);
        }
    }

    private void Update()
    {

    }
}
