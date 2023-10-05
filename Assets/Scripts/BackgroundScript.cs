using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    [SerializeField] private GameObject backgroundObject;
    [SerializeField] private Vector2 parallaxEffectMultiplier;
    private Vector3 camerapositionprev;
    private Transform CameraTransform;
    private float textureUnitSizeX;



    private void Start()
    {
        CameraTransform = Camera.main.transform;
        camerapositionprev = CameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
    }
    // Update is called once per frame
    void LateUpdate()
    { 
        Vector3 deltaMovement = CameraTransform.position - camerapositionprev;
        transform.position += new Vector3 (deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y);
        camerapositionprev = CameraTransform.position;

        //if (Mathf.Abs(CameraTransform.position.x - transform.position.x) >= textureUnitSizeX)
        //{
        //    float offsetPosition = (CameraTransform.position.x - transform.position.x) % textureUnitSizeX;
        //    transform.position = new Vector3(CameraTransform.position.x + offsetPosition, transform.position.y);
        //}
    }

}
