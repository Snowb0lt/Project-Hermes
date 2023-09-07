using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class ShopManager : MonoBehaviour
{


    //Database to hold upgrades
    Dictionary<string, int> StackableUpgrades = new Dictionary<string, int>()
    {
        {"Increase Bounce", 0},
        {"Increase Launcher Force", 0},
    };

    //Database to hold upgrade Costs
    Dictionary<string, int> UpgradeCosts = new Dictionary<string, int>()
    {
        {"Increase Bounce", }
    };

    //To Do: Make a scriptable object to hold the information about the various upgrades

    public static ShopManager _instance;
    void Start()
    {
        LoadMoneyForShop();
        if (_instance == null || _instance != this)
        {
            Destroy(_instance);
            _instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        _coinCounter.text = _totalMoney.ToString();
    }

    private int _totalMoney;
    
    [SerializeField] private TMP_Text _coinCounter;

    private void LoadMoneyForShop()
    {
        _totalMoney = PlayerPrefs.GetInt("Total Money");
        
    }
    
    private void BuyItem(int cost, string item)
    {
        if (_totalMoney >= cost)
        {
            _totalMoney -= cost;
            StackableUpgrades[item] += 1;
            Debug.Log($"{item} has been bought at {cost}");
        }
        else
        {
            Debug.Log("You do not have enough gold");
        }
    }

    /// <summary>
    /// Set the cost and item for button upgrades
    /// </summary>
    [SerializeField] private TMP_Text _upgradeCost;
    [SerializeField] private TMP_Text _upgradeName;
    private int _upgradeCost;
    
    public void BuyButton()
    {
        //To do: Turn the TMP _upgradeCost into an int to be used
        
        BuyItem(_upgradeCost, _upgradeName.ToString());
    }

    /// <summary>
    /// When Done with the shop, these interact
    /// </summary>

    public void SaveStats()
    {
        //Save Upgrade Values
        foreach (KeyValuePair<string, int> upgrades in StackableUpgrades) 
        {
            PlayerPrefs.SetInt(upgrades.Key, upgrades.Value);
        }
        //Save Money after purchases
        PlayerPrefs.SetInt("Total Money", _totalMoney);
    }

    public void BackToLaunch()
    {
        SaveStats();
        SceneManager.LoadScene(0);
    }
}
