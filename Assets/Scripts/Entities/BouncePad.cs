using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour, IObstacle
{
    [SerializeField] private Rigidbody2D padRb;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private GameObject player;

    //To Change the Speed of movement on the fly
    [SerializeField] private int _moveSpeed;

    private void Awake()
    {
        padRb = GetComponent<Rigidbody2D>();
        transform.position = GameObject.Find("Ground").transform.position + new Vector3(0, 2, 0);
    }

    private void Start()
    {
        player = GameObject.Find("Player");
        playerRb = player.gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //transform.Translate(Vector3.left * _moveSpeed * Time.deltaTime);
    }

    public void InteractWithPlayer()
    {
        //Bounces the Player Upward
        playerRb.AddForce(new Vector2(10, 25), ForceMode2D.Impulse);
        Debug.Log("Player hit bounce pad");
    }
}
