using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Stats Screen UI")]
    [SerializeField] private TMP_Text _DayText;
    [SerializeField] private TMP_Text _DistanceText;
    [SerializeField] private TMP_Text _DistanceStatText;
    [SerializeField] private TMP_Text _TotalMoneyText;
    [SerializeField] private TMP_Text _MoneyEarnedText;
    [SerializeField] private GameObject _statsScreen;

    private PlayerData _playerData;

    public static UIManager _instance;

    private void Awake()
    {
        _playerData = GameObject.Find("PlayerData").GetComponent<PlayerData>();
    }
    void Start()
    {
        if (_instance == null || _instance != this)
        {
            Destroy(_instance);
            _instance = this;
        }
    }

    void Update()
    {
        _DistanceText.text = GameManager._instance._distanceFromStart.ToString() + " Meters";
        if (_playerData._longestDistance < GameManager._instance._distanceFromStart && _playerData._longestDistance != 0)
        {
            _DistanceText.text = GameManager._instance._distanceFromStart.ToString() + " Meters - New Record!";
        }
    }

    public void ShowStats()
    {
        Time.timeScale = 0.0f;
        _MoneyEarnedText.text = GameManager._instance._moneyEarned.ToString() + " Coins Earned";
        _TotalMoneyText.text = PlayerData._instance._coins + " Total Coins";
        _DayText.text = "Day " + PlayerData._instance._currentDay;
        _DistanceStatText.text = GameManager._instance._distanceFromStart.ToString() + " Meters";
    }
}
