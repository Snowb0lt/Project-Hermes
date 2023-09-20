using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndingWall : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerRb;

    private void Awake()
    {
        _playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerRb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EndTheGame();
        }
    }
    private void EndTheGame()
    {
        Debug.Log("Game Has Ended. You Win!");
    }
}
