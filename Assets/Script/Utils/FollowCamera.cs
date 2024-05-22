using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Camera _camera;    
    public Transform player{ get; private set; }        

    void Start()
    {
        _camera = Camera.main;
        player = GameManager.Instance.Player;            
    }

    void FixedUpdate()
    {
        _camera.transform.position = new Vector3(player.position.x, player.position.y, -1);
    }
}
