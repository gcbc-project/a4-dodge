using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public ObjectPool ObjectPool { get; private set; }
    public Transform Player { get; private set; }
    public EnemySpawn EnemySpawn { get; private set; }

    protected override void Awake()
    {
        FindObjectPool();
        CreateSelectedCharacter();
        FindEnemySpawn();
    }
    private void FindEnemySpawn()
    {
        EnemySpawn = FindObjectOfType<EnemySpawn>();
    }

    private void FindObjectPool()
    {
        ObjectPool = FindObjectOfType<ObjectPool>();
    }
    private void CreateSelectedCharacter()
    {
        GameObject selectedCharacterPrefab = DataManager.Instance.GetSelectedCharacterPrefab();
        if (selectedCharacterPrefab != null)
        {
            GameObject character = Instantiate(selectedCharacterPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            Player = character.transform;
        }
    }

    public void LoadNextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void GameOver()
    {
        SceneManager.LoadScene("CharacterSelectScene");
    }
}
