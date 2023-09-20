using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndingWall : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void Awake()
    {
        _player = GameObject.FindAnyObjectByType<Player>().GetComponent<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _player.StopThePlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EndTheGame();
        }
    }
    private void EndTheGame()
    {
        Time.timeScale = 0f;
        Debug.Log("Game Has Ended. You Win!");
    }
}
