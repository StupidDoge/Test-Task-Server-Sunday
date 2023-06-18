using UnityEngine;
using UnityEngine.UI;

public class GalleryButton : MonoBehaviour
{
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() => SceneLoader.Instance.LoadSceneAsync(Constants.GALLERY_SCENE_ID));
    }
}
