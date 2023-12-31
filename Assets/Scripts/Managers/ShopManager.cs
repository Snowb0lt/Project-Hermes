using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

/// <summary>
/// Manages the Shop, where one can buy upgrades
/// </summary>
public class ShopManager : MonoBehaviour
{
    //To Do: Make a scriptable object to hold the information about the various upgrades

    public UpgradeSO upgradeSO;

    [SerializeField] private int _chosenUpgrade;

    [SerializeField]private PlayerData _playerData;

    [SerializeField] private UnityEvent startANewRun;

    public static ShopManager _instance;

    private void Awake()
    {
        
        if (_instance == null || _instance != this)
        {
            Destroy(_instance);
            _instance = this;
        }
        _playerData = PlayerData.FindObjectOfType<PlayerData>();

        EventsManager._instance.onDayExtended += OnDaysExtended;
    }

    void Start()
    { 
        _totalMoney = _playerData._coins;
    }

    

    // Update is called once per frame
    void Update()
    {
        _coinCounter.text = _totalMoney.ToString();
        _daysLeftText.text = _playerData._daysLeft.ToString() + " Days Left";
    }


    /// <summary>
    /// Load the amount of money for the player
    /// </summary>
    private int _totalMoney;
    [SerializeField] private TMP_Text _coinCounter;
    [SerializeField] private TMP_Text _daysLeftText;

    /// <summary>
    /// Handle the Buying and adding of Upgrades to Dictionary Values
    /// </summary>
    /// <param name="cost"></param>
    /// <param name="item"></param>
    private void BuyItem(int cost, PlayerData.Stats item, float upgradeAmount)
    {
        //Make an equation cost = cost * (1 + number of times the item was purchased) later to increase the cost of the item in increments
        if (_totalMoney >= cost)
        {
            _totalMoney -= cost;
            if (!_playerData.UpgradeDictionary.ContainsKey(item))
            {
                _playerData.UpgradeDictionary.Add(item, upgradeAmount);
                Debug.Log($"{item} has been added! Dictionary now contains {_playerData.UpgradeDictionary[item]}");
                
                if (upgradeSO._unlockedSpawnable != null)
                {
                    _playerData.UnlockSpawnable(upgradeSO._unlockedSpawnable);
                }

            }
            else
            {
                _playerData.UpgradeDictionary[item] += upgradeAmount;
            }

            Debug.Log($"{item} has been bought at {cost}, current value of Dictionary is {_playerData.UpgradeDictionary[item].ToString()}");    
        }
        else
        {
            Debug.Log("You do not have enough gold");
        }
    }

    /// <summary>
    /// Set what scriptable object is here, and buy the item
    /// </summary>
    private int _upgradeCost;
    [SerializeField] public AudioSource buySound;
    public void BuyButton()
    {
        buySound.Play();
        BuyItem(upgradeSO._upgradeCost, upgradeSO._statToUpgrade, upgradeSO._upgradeAmount);
        //Debug.Log($"Buying {upgradeScriptableObjects._upgradeName} at {upgradeScriptableObjects._upgradeCost}");
        if (upgradeSO._statToUpgrade == PlayerData.Stats.AddDays)
        {
            OnDaysExtended();
        }
    }

    /// <summary>
    /// When Done with the shop, these interact
    /// </summary>

    public void SaveStats()
    {
        //Save Money after purchases
        _playerData._coins = _totalMoney;
    }

    /// <summary>
    /// Extend the Days after buying upgrade
    /// </summary>
    /// 
    public void OnDaysExtended()
    {
        _playerData._daysLeft++;
    }

    //Handle Prerequisites

}
