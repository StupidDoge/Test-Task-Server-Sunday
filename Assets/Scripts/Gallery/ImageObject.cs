using UnityEngine;
using UnityEngine.UI;

public class ImageObject : MonoBehaviour
{
    private RawImage _rawImage;
    private Button _button;

    private int _id;

    private void Awake()
    {
        _rawImage = GetComponent<RawImage>();
        _button = GetComponent<Button>();

        _button.onClick.AddListener(Click);
    }

    public void LoadImage(int id)
    {
        _id = id;
        StartCoroutine(ServerImageLoader.LoadImageFromServer(_rawImage, _id));
    }

    private void Click()
    {
        SceneLoader.Instance.LoadSceneWithImageIndexAsync(Constants.VIEW_SCENE_ID, _id);
    }
}
