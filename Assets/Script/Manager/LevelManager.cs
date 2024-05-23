using System;
using UnityEngine;
using TMPro;
using System.Collections;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private int _currentLevel;
    public int CurrentLevel
    {
        get { return _currentLevel; }
    }
    public event Action OnLevelUpEvent;

    public TMP_Text LevelText;

    void Start()
    {
        OnLevelUpEvent += IncreaseLevel;
        OnLevelUpEvent += ShowLevelUpMessage;  // Subscribe to the event
        if (LevelText != null)
        {
            StartCoroutine(DisplayLevelUpMessage());
        }
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
