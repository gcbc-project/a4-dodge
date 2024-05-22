using System;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    private int _enemyCount;
    private void Start()
    {
        SpawnEnemy(LevelManager.Instance.CurrentLevel);
    }

    public void DestroyEnemy(GameObject entity)
    {
        Destroy(entity);
        if(_enemyCount == 0)
        {
            LevelManager.Instance.LevelUP();
            SpawnEnemy(LevelManager.Instance.CurrentLevel);
        }
    }

    public void SpawnEnemy(int currentLevel)
    {
        for(int i = 0; i<currentLevel; i++)
        {
            Instantiate(_enemyPrefab, new Vector3(5f, (currentLevel - 1) * -0.5f + (i * 1f), 0f), Quaternion.identity, transform);
            Instantiate(_enemyPrefab, new Vector3(-5f, (currentLevel - 1) * -0.5f + (i * 1f), 0f), Quaternion.identity, transform);
        }
        _enemyCount = currentLevel * 2;
    }
}
