using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrade")]
public class UpgradeScriptableObject : ScriptableObject
{
    public string upgradeName;
    public int upgradeCost;

    public string description;

}
