using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndingWall : MonoBehaviour
{

    [SerializeField] GameObject endWall;

    [SerializeField] private GameManager gameManager;
    [SerializeField] private Player _player;

    private void Awake()
    {
        _player = GameObject.FindAnyObjectByType<Player>().GetComponent<Player>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _player.StopThePlayer();
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
