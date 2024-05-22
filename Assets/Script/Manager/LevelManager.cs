using System;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private int _currentLevel;
    public int CurrentLevel
    {
        get { return _currentLevel; }
    }
    public event Action OnLevelChange;
    
    void Start()
    {
        OnLevelChange += IncreaseLevel;
    }

    public void IncreaseLevel()
    {
        _currentLevel++;
    }
}
