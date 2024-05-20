using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public ObjectPool ObjectPool {  get; private set; } // �� �κ� �Ű��ּ���
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                var obj = FindAnyObjectByType<GameManager>();
                if(obj != null)
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
        ObjectPool = GetComponent<ObjectPool>(); // �� �κ� �Ű��ּ���.
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
