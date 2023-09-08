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
    public Dictionary<Stats, float> UpgradeDictionary = new Dictionary<Stats, float>()
    {

    };

    public int _launchForce = 1;
    public int _PlayerBounce = 1;

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


    public enum Stats
    {
        LaunchForce,
        Bounciness,

    }
}
