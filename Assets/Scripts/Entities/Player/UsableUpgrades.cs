using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// This Script...
/// 1) controls The wings
/// 2) Controls the Thrusters
/// 3) Controls Airdash
/// </summary>
public class UsableUpgrades : MonoBehaviour
{
    private PlayerData _playerData;
    private Player _player;

    [Header("Unique Abilities")]
    //Parameters for Wings
    public bool areWingsOut;
    [SerializeField] private GameObject _wingsObject;

    //Parameters for Airdash
    private float dashButtonTimer;
    private float dashButtonCooldown = 0.5f;
    [SerializeField] private float dashAbilityCooldown = 5;
    [SerializeField] private float dashAbilityCooldownTimer;

    //Parameters for Thrusters
    [SerializeField] private Thruster _thrusterScript;
    [SerializeField] private GameObject thrusterObject;

    [Header("Actions")]
    //Wings
    [SerializeField] private UnityEvent WingsOut;
    [SerializeField] private UnityEvent WingsIn;
    //AirDash
    [SerializeField] private UnityEvent AirDash;
    //Thrusters and Fuel
    [SerializeField] private UnityEvent ThrustersOn;
    [SerializeField] private UnityEvent ThrustersOff;

    public static UsableUpgrades _instance;

    private void Awake()
    {
        _instance = this;
        _player = GameObject.FindAnyObjectByType<Player>().GetComponent<Player>();
        _playerData = GameObject.FindAnyObjectByType<PlayerData>().GetComponent<PlayerData>();
    }
    public void Update()
    {
        WingsControls();
        AirDashControls();
        ThrusterControls();
    }
    public void WingsControls()
    {
        if (_playerData.UpgradeDictionary.ContainsKey(PlayerData.Stats.Wings))
        {
            _wingsObject.SetActive(true);
            if (_player._isLaunched)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    //Wings Out
                    if (!areWingsOut)
                    {
                        areWingsOut = true;
                        WingsOut.Invoke();
                    }
                    //Retract Wings
                    if (areWingsOut)
                    {
                        areWingsOut = !areWingsOut;
                        WingsIn.Invoke();
                    }
                }
            }
        }
    }

    public void AirDashControls()
    {
        if (_playerData.UpgradeDictionary.ContainsKey(PlayerData.Stats.AirDash) && _player._isLaunched == true)
        {
            if (Input.GetKeyDown(KeyCode.D) && dashAbilityCooldown > dashAbilityCooldownTimer)
            {
                //Start the cooldown timer for double press;
                dashButtonTimer += Time.deltaTime;
                if (Input.GetKeyDown(KeyCode.D) && dashButtonTimer <= dashButtonCooldown)
                {
                    AirDash.Invoke();
                    Debug.Log("Woosh!)");

                    //Start Cooldown for Dash
                    dashAbilityCooldown = 0;
                }

            }
            //Resets the Timer
            if (dashButtonTimer > dashButtonCooldown)
            {
                dashButtonTimer = 0;
            }

            dashAbilityCooldown += Time.deltaTime;
        }
    }

    public void ThrusterControls()
    {
        if (_playerData.UpgradeDictionary.ContainsKey(PlayerData.Stats.Thrusters))
        {
            thrusterObject.SetActive(true);
            //if(!areWingsOut)
            //{
            //    return;
            //}
            //else
            //{
            if (Input.GetKey(KeyCode.Space))
            {
                ThrustersOn.Invoke();
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                ThrustersOff.Invoke();
            }
            //}

        }
    }
}
