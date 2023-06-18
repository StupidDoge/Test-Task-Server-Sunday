using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ServerImageLoader
{
    public static IEnumerator LoadImageFromServer(RawImage rawImage, int id)
    {
        string path = Constants.SERVER_PATH + id + Constants.JPG_EXTENSION;
        using (UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(path))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(webRequest);
                rawImage.texture = texture;
            }
            else
            {
                Debug.LogError("Image load error: " + webRequest.error);
            }
        }
    }
}
