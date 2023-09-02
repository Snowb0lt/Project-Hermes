using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour, IObstacle
{
    //Interaction as an obstacle
    [SerializeField] private float amountSlowed;
    [SerializeField] private Rigidbody2D enemyRb;
    [SerializeField] private GameObject target;
    [SerializeField] private Rigidbody2D targetRb;

    //Specifically to the guard
    [SerializeField] private int _moveSpeed;

    private void Awake()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        target = GameObject.Find("Player");
        targetRb = target.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //move the enemy to the left
        transform.Translate(Vector3.left * _moveSpeed * Time.deltaTime);
    }
    public void SlowPlayer()
    {

        if (targetRb.velocity.magnitude < 10)
        {
            Debug.Log("Guard has caught you");
            Destroy(targetRb);
        }
        else
        {
            targetRb.AddForce(new Vector2(-amountSlowed, 0), ForceMode2D.Impulse);
            Debug.Log($"Player has been slowed by {amountSlowed}");
            Destroy(gameObject);
        }        
    }
}
