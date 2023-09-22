using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BackgroundScroll : MonoBehaviour
{
    private float scrollSpeed;
    [SerializeField] private float distantSlowdown;
    [SerializeField] private float maxHeight;
    private float offset;

    private Material backgroundMat;
    [SerializeField] private SpriteRenderer backgroundRenderer;
    [SerializeField] private GameObject backgroundSprite;

    private Rigidbody2D playerRb;
    private Player player;


    private void Awake()
    {
        player = GameObject.FindAnyObjectByType<Player>();
        playerRb = GameObject.FindAnyObjectByType<Player> ().GetComponent<Rigidbody2D> ();
        backgroundMat = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerRb = null)
        {
            return;
        }
        else
        {
            backgroundSprite.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, transform.position.z);
            scrollSpeed = playerRb.velocity.x;
            offset += scrollSpeed / distantSlowdown;

            backgroundMat.mainTextureOffset = new Vector2(offset, maxHeight);

        }

    }
}
