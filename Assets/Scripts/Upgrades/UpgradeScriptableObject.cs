using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "ScriptableObjects/Upgrades")]
public class UpgradeScriptableObject : ScriptableObject
{

    public Sprite UpgradeIcon;
    public string _upgradeName;
    public int _upgradeCost;
    public string _upgradeDescription;


}
