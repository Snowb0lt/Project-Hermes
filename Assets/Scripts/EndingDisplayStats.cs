using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndingDisplayStats : MonoBehaviour
{
    [SerializeField] private TMP_Text finalGold;
    [SerializeField] private TMP_Text totalDays;
    [SerializeField] private TMP_Text daysLeft;

    private PlayerData playerData;

    private void Awake()
    {
        playerData = GameObject.FindAnyObjectByType<PlayerData>().GetComponent<PlayerData>();
    }

    private void Update()
    {
        finalGold.text = $"{playerData._coins} Coins";
        totalDays.text = $"Day {playerData._currentDay}";
        daysLeft.text = $"{playerData._daysLeft} Days Left";
    }
}
