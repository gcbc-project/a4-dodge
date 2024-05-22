using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;

    public void SpawnEnemy(int currentLevel)
    {
        for(int i = 0; i<currentLevel; i++)
        {
            Instantiate(_enemyPrefab, new Vector3(5f, (currentLevel - 1) * -0.5f + (i * 1f), 0f), Quaternion.identity, transform);
            Instantiate(_enemyPrefab, new Vector3(-5f, (currentLevel - 1) * -0.5f + (i * 1f), 0f), Quaternion.identity, transform);
        }
    }
}
