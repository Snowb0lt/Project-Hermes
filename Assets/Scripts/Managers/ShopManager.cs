using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class ShopManager : MonoBehaviour
{


    //Database to hold upgrades
    Dictionary<string, int> UpgradeDictionary = new Dictionary<string, int>()
    {
        //{"Increase Bounce", 0},
        //{"Increase Launcher Force", 0},
    };

    //To Do: Make a scriptable object to hold the information about the various upgrades
    
    public UpgradeSO upgradeScriptableObjects;

    [SerializeField] private int _chosenUpgrade;

    [SerializeField]private PlayerData _playerData;


    public static ShopManager _instance;
    private void Awake()
    {

        if (_instance == null || _instance != this)
        {
            Destroy(_instance);
            _instance = this;
        }
        _playerData = PlayerData.FindObjectOfType<PlayerData>();
    }

    void Start()
    {
        _totalMoney = _playerData._coins;
    }

    

    // Update is called once per frame
    void Update()
    {
        _coinCounter.text = _totalMoney.ToString(); 
    }


    /// <summary>
    /// Load the amount of money for the player
    /// </summary>
    private int _totalMoney;
    [SerializeField] private TMP_Text _coinCounter;
    

    /// <summary>
    /// Handle the Buying and adding of Upgrades to Dictionary Values
    /// </summary>
    /// <param name="cost"></param>
    /// <param name="item"></param>
    private void BuyItem(int cost, string item)
    {
        if (_totalMoney >= cost)
        {
            _totalMoney -= cost;
            if (!UpgradeDictionary.ContainsKey(item))
            {
                UpgradeDictionary.TryAdd(item, 1);
            }
            else
            {
                UpgradeDictionary[item]++;
            }

            Debug.Log($"{item} has been bought at {cost}, current value of Dictionary is {UpgradeDictionary[item].ToString()}");
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
    
    public void BuyButton()
    {
        BuyItem(upgradeScriptableObjects._upgradeCost, upgradeScriptableObjects._upgradeName);

        //Debug.Log($"Buying {upgradeScriptableObjects._upgradeName} at {upgradeScriptableObjects._upgradeCost}");

    }

    /// <summary>
    /// When Done with the shop, these interact
    /// </summary>

    public void SaveStats()
    {
        //Save Upgrade Values
        foreach (KeyValuePair<string, int> upgrades in UpgradeDictionary) 
        {
            PlayerPrefs.SetInt(upgrades.Key, upgrades.Value);
        }
        //Save Money after purchases
        _playerData._coins = _totalMoney;
    }

    public void BackToLaunch()
    {
        SaveStats();
        SceneManager.LoadScene(0);
    }
}
