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
    [SerializeField] private TMP_Text _TotalMoneyText;
    [SerializeField] private TMP_Text _MoneyEarnedText;
    [SerializeField] private GameObject _statsScreen;


    public static UIManager _instance;
    // Start is called before the first frame update
    void Start()
    {
        if (_instance == null || _instance != this)
        {
            Destroy(_instance);
            _instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        _DistanceText.text = GameManager._instance._distanceFromStart.ToString() + " Meters";
    }

    public void ShowStats()
    {

        _MoneyEarnedText.text = GameManager._instance._moneyEarned.ToString();
        _TotalMoneyText.text = GameManager._instance._totalMoney.ToString();
    }
}
