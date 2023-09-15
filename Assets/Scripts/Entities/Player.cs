using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour
{
    [SerializeField] private bool _isLaunched;

    //Base Stats
    [SerializeField] private float _baseLaunchForce = 25f;
    [SerializeField] private float _finalLaunchForce;
    [SerializeField] private PhysicsMaterial2D _bounciness;

    //Unity Events
    [SerializeField] private UnityEvent GameBegun;
    [SerializeField] private UnityEvent ShowStats;

    //Abilities
    [SerializeField] private UnityEvent WingsOut;
    [SerializeField] private UnityEvent WingsIn;
    [SerializeField] private UnityEvent AirDash;

    //Dependencies
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private Rigidbody2D _playerRb;
    [SerializeField] private Ground _ground;

    // Start is called before the first frame update
    void Start()
    {
        _playerRb.GetComponent<Rigidbody2D>();
        _playerData = FindObjectOfType<PlayerData>();
        _ground = FindObjectOfType<Ground>();
        _isLaunched = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Launch The Kobold
        KoboldLaunched();
        //Check For Unique Upgrades
        UniqueUpgrades();
    }

    private void KoboldLaunched()
    {
        //Affect Launching
        if (!_isLaunched)
        {
            if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump"))
            {
                _finalLaunchForce = _baseLaunchForce * (1 + _playerData.UpgradeDictionary[PlayerData.Stats.LaunchForce]);
                Debug.Log($"Player launching at {_finalLaunchForce} {_finalLaunchForce / 2}" + $"Player Bounciness is {_bounciness.bounciness}");
                _isLaunched = true;
                GameBegun?.Invoke();
                _playerRb.AddForce(new Vector2(_finalLaunchForce, (_finalLaunchForce / 2)), ForceMode2D.Impulse);
                
            }
            
        }
        //Affect Player Bounciness
        
        
    }
    /// <summary>
    /// Controls when the player hits an obstacle and the minimum speed for the player to stop completely.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IObstacle obstacle = collision.gameObject.GetComponent<IObstacle>();
        
        if (_isLaunched && obstacle != null)
        {
            WingsIn?.Invoke();
            obstacle.InteractWithPlayer();
            //hit an obstacle
            //if (_playerRb.velocity.x > 2)
            //{
            //    obstacle.InteractWithPlayer();
            //}
            //if (_playerRb.velocity.x <= 2)
            //{
            //    //CheckIfPlayerGrounded(collision);
            //}
        }
    }

    //private void CheckIfPlayerGrounded(Collision2D collision)
    //{
    //    if (collision.gameObject.GetComponent<IGroundable>() != null)
    //    {
    //        StopThePlayer();
    //    }
    //    else
    //    {
    //        Debug.Log("Non-grounding target hit");
    //    }
    //}

    public void StopThePlayer()
    {
        _playerRb.velocity = Vector2.zero;
        Destroy(_playerRb);
        //Get Distance from Start
        GameManager._instance.GetDistanceFromStart();
        GameManager._instance.SaveCoinTotal();
        ShowStats?.Invoke();

        Debug.Log("Player has Stopped");
        Destroy(this);
    }

    private float _groundedTimer;
    private void OnCollisionStay2D(Collision2D collision)
    {
        //prevent the player from rolling indefinitely
        if (collision.gameObject.CompareTag("Ground") && _isLaunched && GameManager._instance._distanceFromStart >= 5)
        {
            _groundedTimer += Time.deltaTime;
            if (_playerRb.velocity.x > 2)
            {
                _playerRb.velocity = new Vector2(_playerRb.velocity.x - _bounciness.friction, (1 * _bounciness.bounciness + _playerData.UpgradeDictionary[PlayerData.Stats.Bounciness])) * Time.deltaTime;
            }
            if (_playerRb.velocity.x <= 2 && _groundedTimer >= 0.5)
            {
                StopThePlayer();
            }

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _groundedTimer = 0;
        }
    }

    [Header("Unique Abilities")]
    //Parameters for Wings
    private bool areWingsOut = false;

    //Parameters for Airdash
    private float dashButtonTimer;
    private float dashButtonCooldown = 0.5f;
    [SerializeField]private float dashAbilityCooldown = 5;
    [SerializeField]private float dashAbilityCooldownTimer;
    public void UniqueUpgrades()
    {
        //Wings
        if (_playerData.UpgradeDictionary.ContainsKey(PlayerData.Stats.Wings) && _isLaunched == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (!areWingsOut)
                {
                    WingsOut.Invoke();
                    areWingsOut = true;
                }

                if (areWingsOut)
                {
                    areWingsOut = false;
                    WingsIn.Invoke();
                }
            }

        }

        //Air Dash
        
        if (_playerData.UpgradeDictionary.ContainsKey(PlayerData.Stats.AirDash) && _isLaunched == true)
        {
            if (Input.GetKeyDown(KeyCode.D) && dashAbilityCooldown > dashAbilityCooldownTimer)
            {
                //Start the cooldown timer for double press;
                dashButtonTimer += Time.deltaTime;
                if (Input.GetKeyDown(KeyCode.D) && dashButtonTimer<= dashButtonCooldown)
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
}
