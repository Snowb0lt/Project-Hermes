using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayUpgrade : MonoBehaviour
{

    [SerializeField] private UpgradeSO upgrade;

    [SerializeField] private GameObject UpgradeStats;

    //Locations of TMP objects
    [SerializeField] private TMP_Text _upgradeNameText;
    [SerializeField] private TMP_Text _upgradeCostText;
    [SerializeField] private TMP_Text _upgradeDescriptionText;

    [SerializeField] private ShopManager _shopManager;

    public void SetAndDisplayUpgrade()
    {
        if (!UpgradeStats.activeSelf)
        {
            UpgradeStats.SetActive(true);
        }

        _upgradeDescriptionText.text = upgrade._upgradeDescription;
        _upgradeCostText.text = upgrade._upgradeCost.ToString() + " Coins";
        _upgradeNameText.text = upgrade._upgradeName;

        //Change Scriptable Object of ShopManager
        _shopManager.upgradeScriptableObjects = upgrade;
    }
}
