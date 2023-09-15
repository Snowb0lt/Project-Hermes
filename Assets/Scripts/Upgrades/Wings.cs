using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wings : MonoBehaviour
{

    [SerializeField] private PlayerData _playerData;
    [SerializeField] private bool _areWingsEnabled;

    //GameObject itself
    [SerializeField] private GameObject _wingsObject;

    //Player Interactions
    [SerializeField] private GameObject _player;
    [SerializeField] private Rigidbody2D _playerRb;
    private void Awake()
    {
        _playerData = GameObject.Find("PlayerData").GetComponent<PlayerData>();
        _player = GameObject.Find("Player");
        _playerRb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    //trigger what happens from the Player script event
    public void ActivateWings()
    {
        _wingsObject.SetActive(true);
        _player.transform.rotation = Quaternion.Euler(0,0,-90);
        _playerRb.velocity = new Vector2(_playerRb.velocity.x, 0);
        _playerRb.gravityScale = 0.5f;
    }

    public void DeactivateWings()
    {
        _wingsObject.SetActive(false);
        _playerRb.gravityScale = 1;
    }
}
