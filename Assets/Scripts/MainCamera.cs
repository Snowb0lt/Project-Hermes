using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _cameraOffset;
    [SerializeField] private Camera _camera;
    // Start is called before the first frame update
    
    private void Start()
    {
        _camera = GetComponent<Camera>();
        _camera = Camera.main;
    }


    private void LateUpdate()
    {
        transform.position = _player.position + _cameraOffset;
    }
}
