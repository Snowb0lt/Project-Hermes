using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour, IObstacle
{
    [SerializeField] private Rigidbody2D padRb;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private GameObject player;

    private void Awake()
    {
        padRb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        player = GameObject.Find("Player");
        playerRb = player.gameObject.GetComponent<Rigidbody2D>();
    }

    public void InteractWithPlayer()
    {
        //Bounces the Player Upward
        playerRb.AddForce(new Vector2(10, 25), ForceMode2D.Impulse);
        Debug.Log("Player hit bounce pad");
    }
}
