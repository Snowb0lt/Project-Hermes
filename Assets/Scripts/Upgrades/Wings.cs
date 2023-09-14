using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wings : MonoBehaviour
{

    [SerializeField] private PlayerData _playerData;
    [SerializeField] private bool _areWingsEnabled;
    private void Awake()
    {
        _playerData = GameObject.Find("PlayerData").GetComponent<PlayerData>();
    }

    //trigger what happens from the Player script event
    private void ActivateWings()
    {
        if (_playerData.UpgradeDictionary.ContainsKey(PlayerData.Stats.Wings))
        {
            
        }
    }
}
