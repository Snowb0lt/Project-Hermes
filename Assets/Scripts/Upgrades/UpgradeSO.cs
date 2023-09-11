using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "ScriptableObjects/Upgrades")]
public class UpgradeSO : ScriptableObject
{

    public Sprite UpgradeIcon;
    public string _upgradeName;
    public int _upgradeCost;
    public string _upgradeDescription;


    public PlayerData.Stats _statToUpgrade;
    public float _upgradeAmount;
    public bool _upgradeUnlocked;

    public GameObject _unlockedSpawnable;

    public void CheckIfSpawnable()
    {
        if (_unlockedSpawnable == null)
        {
            return;
        }
    }
}
