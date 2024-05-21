using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartBtn : MonoBehaviour
{
    private Button _button;
    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void Update()
    {
        _button.interactable = DataManager.Instance.CharaID != 0;
    }

    public void OnClick()
    {
        SceneManager.LoadScene(1);
    }
}
