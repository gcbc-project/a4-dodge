using UnityEngine;

public class CharaBtn : MonoBehaviour
{
    [SerializeField] private int _charaId;
    // Start is called before the first frame update
    
    public void OnClick()
    {
        DataManager.Instance.CharaID = _charaId;
    }
}
