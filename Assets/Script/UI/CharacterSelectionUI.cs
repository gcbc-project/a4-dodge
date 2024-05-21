using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionUI : MonoBehaviour
{
    public List<GameObject> CharacterPrefabs;
    public GameObject ButtonPrefab; // 버튼 프리펩
    public Transform ButtonContainer; // 버튼들이 담길 부모 객체 (예: Grid Layout Group이 적용된 Panel)
    public Camera RenderCameraPrefab; // 캐릭터를 렌더링할 카메라 프리펩
    public Vector3 CameraOffset; // 카메라의 오프셋 위치
    public float CharacterSpacing = 3.0f; // 캐릭터 간격

    private List<RenderTexture> renderTextures = new List<RenderTexture>();
    private List<GameObject> characterInstances = new List<GameObject>();

    private void Start()
    {
        PopulateCharacterButtons();
    }

    private void PopulateCharacterButtons()
    {
        // 기존 버튼들을 제거합니다.
        foreach (Transform child in ButtonContainer)
        {
            Destroy(child.gameObject);
        }

        // 캐릭터 프리펩 리스트를 순회하면서 버튼을 생성합니다.
        for (int i = 0; i < CharacterPrefabs.Count; i++)
        {
            GameObject button = Instantiate(ButtonPrefab, ButtonContainer);
            int index = i; // 로컬 변수로 인덱스를 저장합니다.

            // 각 캐릭터 프리펩을 위한 RenderTexture와 카메라를 설정합니다.
            RenderTexture renderTexture = new RenderTexture(256, 256, 16);
            renderTextures.Add(renderTexture);

            Camera renderCamera = Instantiate(RenderCameraPrefab, gameObject.transform);
            renderCamera.targetTexture = renderTexture;

            // 캐릭터와 카메라의 위치를 설정합니다.
            Vector3 characterPosition = new Vector3(i * CharacterSpacing, 0, 0);
            Vector3 cameraPosition = characterPosition + CameraOffset;

            // 버튼의 RawImage에 RenderTexture를 설정합니다.
            RawImage buttonImage = button.GetComponentInChildren<RawImage>();
            if (buttonImage != null)
            {
                buttonImage.texture = renderTexture;
            }

            // 캐릭터 인스턴스를 생성하고 카메라가 바라보게 설정합니다.
            GameObject characterInstance = Instantiate(CharacterPrefabs[i], gameObject.transform);
            RemoveUnnecessaryComponents(characterInstance);
            characterInstances.Add(characterInstance);
            characterInstance.transform.position = characterPosition;
            renderCamera.transform.position = cameraPosition;

            // 버튼 클릭 이벤트를 설정합니다.
            Button btn = button.GetComponent<Button>();
            if (btn != null)
            {
                btn.onClick.AddListener(() => SelectCharacter(index));
            }

            // 버튼의 텍스트나 이미지를 설정하는 코드를 추가할 수 있습니다.
            Text buttonText = button.GetComponentInChildren<Text>();
            if (buttonText != null)
            {
                buttonText.text = CharacterPrefabs[i].name;
            }
        }
    }

    private void RemoveUnnecessaryComponents(GameObject characterInstance)
    {
        // Animator를 제외한 모든 컴포넌트를 제거합니다.
        Component[] components = characterInstance.GetComponents<Component>();
        foreach (Component component in components)
        {
            if (component is Animator || component is Transform)
                continue;

            Destroy(component);
        }
    }

    private void SelectCharacter(int index)
    {
        // 캐릭터 선택 처리 (예: 선택된 캐릭터를 게임 시작 시 사용할 수 있게 함).
        Debug.Log("Selected character index: " + index);
    }

    private void OnDestroy()
    {
        // 생성된 RenderTexture를 해제합니다.
        foreach (var renderTexture in renderTextures)
        {
            renderTexture.Release();
        }

        // 캐릭터 인스턴스를 제거합니다.
        foreach (var characterInstance in characterInstances)
        {
            Destroy(characterInstance);
        }
    }
}
