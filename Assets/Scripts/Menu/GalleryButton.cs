using UnityEngine;
using UnityEngine.UI;

public class GalleryButton : MonoBehaviour
{
    [SerializeField] private LoadingCanvas _loadingCanvas;

    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();

        _button.onClick.AddListener(() => _loadingCanvas.gameObject.SetActive(true));
    }
}
