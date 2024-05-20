using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public Transform Player { get; private set; }
    public ObjectPool ObjectPool { get; private set; }
    [SerializeField] private string _playerTag;
        
    void Update()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        Player = GameObject.FindGameObjectWithTag(_playerTag).transform;
        ObjectPool = GetComponent<ObjectPool>();
    }
}
