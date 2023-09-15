using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour, IObstacle, IGroundable
{
    //Interaction as an obstacle
    [SerializeField] private float amountSlowed;
    [SerializeField] private Rigidbody2D enemyRb;
    [SerializeField] private Player target;
    [SerializeField] private Rigidbody2D targetRb;

    //Specifically to the guard
    [SerializeField] private int _moveSpeed;

    private void Awake()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<Player>();
        targetRb = target.gameObject.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        transform.position = GameObject.Find("Ground").transform.position + new Vector3(0, 2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //move the enemy to the left
        transform.Translate(Vector3.left * _moveSpeed * Time.deltaTime);
    }
    public void InteractWithPlayer()
    {
        //Guard Slows the Player Down
        if (targetRb.velocity.magnitude < 10)
        {
            targetRb.velocity = Vector3.zero;
            Debug.Log("Guard has caught you");
            target.StopThePlayer();
        }
        else
        {
            targetRb.AddForce(new Vector2(-amountSlowed, 0), ForceMode2D.Impulse);
            Debug.Log($"Player has been slowed by {amountSlowed}");
            Destroy(gameObject);
        }        
    }
}
