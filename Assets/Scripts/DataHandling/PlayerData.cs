using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;


/// <summary>
/// Houses the player's stats and upgrades between scenes
/// </summary>


public class PlayerData : MonoBehaviour
{
    //Player Stats

    public int _coins;
    public int _dayNumber;
    public int _currentDay = 0;
    [SerializeField]public int _daysLeft = 100;
    public int _longestDistance;

    //Player Upgrades
    public Dictionary<Stats, float> UpgradeDictionary = new Dictionary<Stats, float>()
    {

    };


    public List<GameObject> UnlockedSpawnables = new List<GameObject>()
    {

    };
    public int _launchForce = 1;
    public int _PlayerBounce = 1;

    //DayManager
    public void ChangeTheDays()
    {
        _currentDay++;
        _daysLeft--;
    }

    //Link to Scriptable Object
    public UpgradeSO upgradeSO;

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
        UpgradeDictionary.Add(Stats.LaunchForce, 0);
        UpgradeDictionary.Add(Stats.Bounciness, 0);
    }

    private void Update()
    {

    }

    /// <summary>
    /// Certain Objects are unlockable (bounce pads, wings, etc.). This controls unlocking them
    /// </summary>
    /// <param name="ObjectUnlocked"></param>
    /// <param name="ObjectInDictionary"></param>
    public void UnlockSpawnable(GameObject unlockedSpawnable)
    {
            UnlockedSpawnables.Add(unlockedSpawnable);
            Debug.Log($"{unlockedSpawnable} is unlocked!");

    }
    public enum Stats
    {
        LaunchForce,
        Bounciness,
        BouncePadUnlocked,
        AirBoost,
        AirDash,
        Slam,
        Wings,
        Thrusters,
        Fuel,
        AddDays,
        GoldPerRun,

    }
}
   

