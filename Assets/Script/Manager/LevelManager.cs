using System;
using UnityEngine;
using TMPro;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    private static LevelManager _instance;
    public static LevelManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = (LevelManager)FindObjectOfType(typeof(LevelManager));

                if (_instance == null)
                {
                    GameObject obj = new GameObject(typeof(LevelManager).Name, typeof(LevelManager));
                    _instance = obj.AddComponent<LevelManager>();
                }
            }

            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as LevelManager;
        }
    }


    [SerializeField] private int _currentLevel;
    public int CurrentLevel
    {
        get { return _currentLevel; }
    }
    public event Action OnLevelUpEvent;

    public TMP_Text LevelText;
    public TMP_Text KillText;

    void Start()
    {
        OnLevelUpEvent += IncreaseLevel;
        OnLevelUpEvent += ShowLevelUpMessage;  // Subscribe to the event
        if (LevelText != null)
        {
            StartCoroutine(DisplayLevelUpMessage());
        }
    }
    public void SetKillCount(int count)
    {
        KillText.text = "처치한 적 : " + count.ToString();
    }

    public void IncreaseLevel()
    {
        if (_currentLevel > 5) return;
        _currentLevel++;
    }

    public void LevelUPEvent()
    {
        OnLevelUpEvent?.Invoke();
    }

    private void ShowLevelUpMessage()
    {
        StartCoroutine(DisplayLevelUpMessage());
    }

    private IEnumerator DisplayLevelUpMessage()
    {
        if (LevelText != null)
        {
            LevelText.text = "Level " + CurrentLevel.ToString();
            LevelText.enabled = true; // Show the text

            yield return new WaitForSeconds(1); // Wait for 3 seconds

            LevelText.enabled = false; // Hide the text after 3 seconds
        }
    }
}
