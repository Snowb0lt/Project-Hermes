using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airdash : MonoBehaviour
{
    private Player player;
    private Rigidbody2D playerRb;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        playerRb = player.gameObject.GetComponent<Rigidbody2D>();
    }
    public void ActivateAirDash() 
    {
        playerRb.AddForce(new Vector2(5, 0), ForceMode2D.Impulse);
        Debug.Log("Airdash Performed;");
    }
}
