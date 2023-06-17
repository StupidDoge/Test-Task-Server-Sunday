using UnityEngine;
using UnityEngine.UI;

public class GalleryButton : MonoBehaviour
{
    [SerializeField] private int _gallerySceneIndex;

    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();

        _button.onClick.AddListener(() => EventBus.OnSceneLoadTriggered?.Invoke(Constants.GALLERY_SCENE_ID));
    }
}
