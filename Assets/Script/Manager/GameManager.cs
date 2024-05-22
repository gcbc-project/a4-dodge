using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private static GameManager _instance;
    public ObjectPool ObjectPool { get; private set; }
    public Transform Player { get; private set; }

    protected override void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += this.OnSceneLoaded;
        }
        else if (_instance != this)
        {
            SceneManager.sceneLoaded -= _instance.OnSceneLoaded;
            Destroy(gameObject);
        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindObjectPool();
        CreateSelectedCharacter();
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
}
