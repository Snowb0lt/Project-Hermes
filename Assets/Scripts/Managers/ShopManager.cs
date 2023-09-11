using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

public class ShopManager : MonoBehaviour
{
    //To Do: Make a scriptable object to hold the information about the various upgrades

    public UpgradeSO upgradeSO;

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
    private void BuyItem(int cost, PlayerData.Stats item, float upgradeAmount)
    {
        if (_totalMoney >= cost)
        {
            _totalMoney -= cost;
            if (!_playerData.UpgradeDictionary.ContainsKey(item))
            {
                _playerData.UpgradeDictionary.TryAdd(item, upgradeAmount);
                _playerData.UnlockUpgrade(upgradeSO._unlockedSpawnable);
                //_playerData.UnlockUpgrade(upgradeScriptableObjects._upgradeUnlocked, item);

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
    
    public void BuyButton()
    {
        BuyItem(upgradeSO._upgradeCost, upgradeSO._statToUpgrade, upgradeSO._upgradeAmount);

        //Debug.Log($"Buying {upgradeScriptableObjects._upgradeName} at {upgradeScriptableObjects._upgradeCost}");

    }

    /// <summary>
    /// When Done with the shop, these interact
    /// </summary>

    public void SaveStats()
    {
        //Save Money after purchases
        _playerData._coins = _totalMoney;
    }

    public void BackToLaunch()
    {
        SaveStats();
        SceneManager.LoadScene(0);
    }
}
