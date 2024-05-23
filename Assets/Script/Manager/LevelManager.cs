using System;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private int _currentLevel;
    public int CurrentLevel
    {
        get { return _currentLevel; }
    }
    public event Action OnLevelUpEvent;
    
    void Start()
    {
        OnLevelUpEvent += IncreaseLevel;
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
}
