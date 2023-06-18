using UnityEngine;
using UnityEngine.UI;

public class ViewLoader : MonoBehaviour
{
    [SerializeField] private Image _image;

    private void Awake()
    {
        StartCoroutine(ServerImageLoader.LoadImageFromServer(_image, SceneLoader.Instance.ImageIndex));
    }
}
