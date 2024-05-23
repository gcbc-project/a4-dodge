using System;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject _rangeEnemyPrefab;
    [SerializeField] private GameObject _meleeEnemyPrefab;
    private int _enemyCount;
    private void Start()
    {
        LevelManager.Instance.OnLevelUpEvent += SpawnEnemy;
        SpawnEnemy();
    }

    public void DestroyEnemy(GameObject entity)
    {
        Destroy(entity);
        if(--_enemyCount == 0)
        {
            LevelManager.Instance.LevelUPEvent();
        }
    }

    public void SpawnEnemy()
    {
        for (int i = 0; i < LevelManager.Instance.CurrentLevel; i++)
        {
            Instantiate(_rangeEnemyPrefab, new Vector3(5f, (LevelManager.Instance.CurrentLevel - 1) * -0.5f + (i * 1f), 0f), Quaternion.identity, transform);
            Instantiate(_rangeEnemyPrefab, new Vector3(-5f, (LevelManager.Instance.CurrentLevel - 1) * -0.5f + (i * 1f), 0f), Quaternion.identity, transform);

            Instantiate(_meleeEnemyPrefab, new Vector3(8.5f, (LevelManager.Instance.CurrentLevel - 1) * -0.5f + (i * 1f), 0f), Quaternion.identity, transform);
            Instantiate(_meleeEnemyPrefab, new Vector3(-8.5f, (LevelManager.Instance.CurrentLevel - 1) * -0.5f + (i * 1f), 0f), Quaternion.identity, transform);
        }
        _enemyCount = LevelManager.Instance.CurrentLevel * 4;
    }
}
