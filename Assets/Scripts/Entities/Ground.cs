using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ground : MonoBehaviour, IObstacle
{
    private Rigidbody2D _groundRb;
    [SerializeField] private GameObject _player;
    [SerializeField] private Rigidbody2D _playerRb;
    [SerializeField] private float _groundOffset;

    //Interaction with player as an obstacle
    [SerializeField] private float amountSlowed;

    // Start is called before the first frame update
    void Start()
    {
        _groundRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector2((_player.transform.position.x + _groundOffset), transform.position.y);
    }

    public void InteractWithPlayer()
    {
        //Slow the Player Down upon impact
        _playerRb.AddForce(new Vector2(-amountSlowed, 0), ForceMode2D.Impulse);
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.rigidbody.AddForce(new Vector2(0, -0.5f), ForceMode2D.Impulse);
        }
    }
}
