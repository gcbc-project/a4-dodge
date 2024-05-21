using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectManager : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Transform buttonParent;
    public GameObject buttonPrefab;

    private void Start()
    {
        CreateCharacterButtons();
    }

    private void CreateCharacterButtons()
    {
        for (int i = 0; i < characterPrefabs.Length; i++)
        {
            GameObject button = Instantiate(buttonPrefab, buttonParent);
            int index = i;
            button.GetComponent<Button>().onClick.AddListener(() => SelectCharacter(index));
            button.transform.GetChild(0).GetComponent<Image>().sprite = characterPrefabs[i].GetComponent<SpriteRenderer>().sprite;
        }
    }

    public void SelectCharacter(int characterIndex)
    {
        // GameManager.Instance.selectedCharacterPrefab = characterPrefabs[characterIndex];
        SceneManager.LoadScene("GameScene");
    }
}
