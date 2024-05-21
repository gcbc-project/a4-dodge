using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager _instance;

    public static DataManager Instance
    {
        get
        {
            if (_instance == null)
            {
                var obj = FindAnyObjectByType<DataManager>();
                if (obj != null)
                {
                    _instance = obj;
                }
                else
                {
                    _instance = new GameObject("DataManager").AddComponent<DataManager>();
                }
            }
            return _instance;
        }
    }

    public int CharaID;

    // Start is called before the first frame update

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
    }
}
