using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bird : MonoBehaviour, IObstacle
{
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private Rigidbody2D birdRb;
    [SerializeField] private GameObject player;
    [SerializeField] private int flightspeed;
    [SerializeField] private int amountSlowed;

    private void Awake()
    {
        birdRb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        player = GameObject.Find("Player");
        playerRb = player.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector2.left * flightspeed * Time.deltaTime);
    }

    public void InteractWithPlayer()
    {
        playerRb.AddForce(new Vector2(-amountSlowed, 0), ForceMode2D.Impulse);
        Debug.Log($"Player has been slowed by {amountSlowed}");
        Destroy(gameObject);
    }
}
