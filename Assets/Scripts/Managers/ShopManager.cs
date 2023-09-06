using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    void Awake()
    {
        LoadMoneyForShop();
    }

    // Update is called once per frame
    void Update()
    {
        _coinCounter.text = _totalMoney.ToString();
    }

    private int _totalMoney;
    private int _testcost = 10;
    [SerializeField] private TMP_Text _coinCounter;

    private void LoadMoneyForShop()
    {
        _totalMoney = PlayerPrefs.GetInt("Total Money");
        
    }
    
    //Test money subtraction and money between scenes
    private void BuyItem(int cost)
    {
        if (_totalMoney >= cost)
        {
            _totalMoney -= cost;
        }
        else
        {
            Debug.Log("You do not have enough gold");
        }
    }

    public void MoneySink()
    {
        BuyItem(_testcost);
    }

    //When Done with the shop

    public void SaveStats()
    {

        //Save Money after purchases
        PlayerPrefs.SetInt("Total Money", _totalMoney);
    }

    public void BackToLaunch()
    {
        SaveStats();
        SceneManager.LoadScene(0);
    }
}
