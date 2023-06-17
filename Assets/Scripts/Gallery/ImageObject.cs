using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageObject : MonoBehaviour
{
    private RawImage _rawImage;
    private Button _button;

    private int _id;

    private void Start()
    {
        _rawImage = GetComponent<RawImage>();
        _button = GetComponent<Button>();

        _button.onClick.AddListener(Click);
    }

    public void SetImageId(int id)
    {
        _id = id;
        StartCoroutine(LoadImageFromServer());
    }

    private IEnumerator LoadImageFromServer()
    {
        using (UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(BuildPath()))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(webRequest);

                _rawImage.texture = texture;
            }
            else
            {
                Debug.LogError("Image load error: " + webRequest.error);
            }
        }
    }

    private string BuildPath()
    {
        return Constants.SERVER_PATH + _id + Constants.JPG_EXTENSION;
    }

    private void Click()
    {
        EventBus.OnSceneLoadTriggered?.Invoke(Constants.VIEW_SCENE_ID);
    }
}
