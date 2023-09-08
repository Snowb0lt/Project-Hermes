using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerRb;
    [SerializeField] private bool _isLaunched = false;

    [SerializeField] private float _launchForce;
    [SerializeField] private float _launchHeight;

    [SerializeField] private UnityEvent GameBegun;
    [SerializeField] private UnityEvent ShowStats;

    // Start is called before the first frame update
    void Start()
    {
        _playerRb.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Launch The Kobold
        if (!_isLaunched)
        {
            if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump"))
            {
                _isLaunched = true;
                GameBegun?.Invoke();
                _playerRb.AddForce(new Vector2(_launchForce, _launchHeight), ForceMode2D.Impulse);
                Debug.Log($"Player launching at {_launchForce} {_launchHeight}");
            }


        }

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
            if (_playerRb.velocity.x > 2.0f)
            {
                obstacle.SlowPlayer();
            }
            if (_playerRb.velocity.x <= 2)
            {
                StopThePlayer();
            }
        }
    }
    private void StopThePlayer()
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
}
