using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Camera _camera;    
    public Transform PlayerPosition { get; private set; }  

    void Start()
    {
        _camera = Camera.main;
        PlayerPosition = GameManager.Instance.Player;            
    }

    void FixedUpdate()
    {
        Vector3 newPosition = Vector2.Lerp(_camera.transform.position, PlayerPosition.position, Time.deltaTime * 5f);
        newPosition.z = _camera.transform.position.z;
        _camera.transform.position = newPosition;
    }
}
