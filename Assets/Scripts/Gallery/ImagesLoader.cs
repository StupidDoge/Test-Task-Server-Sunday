using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class ImagesLoader : MonoBehaviour
{
    [SerializeField] private ImageObject _imageObject;
    [SerializeField] private Transform _imagesParent;

    private int _imagesCount;

    private void Start()
    {
        StartCoroutine(GetImagesCount());
    }

    private IEnumerator GetImagesCount()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(Constants.SERVER_PATH))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                string directoryListing = webRequest.downloadHandler.text.ToString();
                string[] files = directoryListing.Split('\n');

                foreach (string file in files)
                {
                    if (!string.IsNullOrEmpty(file))
                    {
                        if (file.Contains(Constants.JPG_EXTENSION, StringComparison.OrdinalIgnoreCase))
                        {
                            _imagesCount++;
                        }
                    }
                }

                for (int i = 1; i <= _imagesCount; i++)
                {
                    SpawnImages(i);
                }
            }
            else
            {
                Debug.Log("Server connection failed: " + webRequest.error);
            }
        }
    }

    private void SpawnImages(int imageId)
    {
        ImageObject imageObject = Instantiate(_imageObject, _imagesParent);
        imageObject.SetImageId(imageId);
    }
}
