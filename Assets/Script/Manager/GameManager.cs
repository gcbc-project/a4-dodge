using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public ObjectPool ObjectPool { get; private set; }
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                var obj = FindAnyObjectByType<GameManager>();
                if (obj != null)
                {
                    _instance = obj;
                }
                else
                {
                    _instance = new GameObject("GameManager").AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }
    public Transform Player { get; private set; }
    [SerializeField] private string _playerTag;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        ObjectPool = GetComponent<ObjectPool>();
    }

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag(_playerTag).transform;
    }
}
