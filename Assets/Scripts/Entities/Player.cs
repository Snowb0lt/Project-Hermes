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
            //hit an obstacle
            if (_playerRb.velocity.x > 2)
            {
                obstacle.InteractWithPlayer();
            }
            if (_playerRb.velocity.x <= 2)
            {
                CheckIfPlayerGrounded(collision);
            }
        }
    }

    private void CheckIfPlayerGrounded(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<IGroundable>() != null)
        {
            StopThePlayer();
        }
        else
        {
            Debug.Log("Non-grounding target hit");
        }
    }

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



    public void WingControls()
    {
        if (_playerData.UpgradeDictionary.ContainsKey(PlayerData.Stats.Wings) && _isLaunched)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {

            }
        }
    }
}
