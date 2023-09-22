using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField]private float scrollSpeed;
    [SerializeField] private float distantSlowdown;
    [SerializeField] private float maxHeight;
    private float offset;

    [SerializeField]private Material backgroundMat;

    private Rigidbody2D playerRb;
    private Player player;


    private void Awake()
    {
        player = GameObject.FindAnyObjectByType<Player>().GetComponent<Player>();
        playerRb = player.GetComponent<Rigidbody2D>();
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
            offset += scrollSpeed / distantSlowdown;

            backgroundMat.mainTextureOffset = (new Vector2(offset, 1));

        }

    }
}
