using UnityEngine;

public class DataManager : Singleton<DataManager>
{
  [SerializeField] private GameObject _selectedCharacterPrefab;
  public void SetSelectedCharacterPrefab(GameObject characterPrefab)
  {
    _selectedCharacterPrefab = characterPrefab;
  }

  public GameObject GetSelectedCharacterPrefab()
  {
    return _selectedCharacterPrefab;
  }
}