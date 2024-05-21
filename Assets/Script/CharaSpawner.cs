using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _playerPool;
    // Start is called before the first frame update
    private void Awake()
    {
        Instantiate(_playerPool[DataManager.Instance.CharaID - 1]);
    } 
}
