using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class ImagesLoader : MonoBehaviour
{
    [SerializeField] private ImageObject _imageObject;
    [SerializeField] private Transform _imagesParent;
    [SerializeField] private int _imagesPortionSpawnSize;

    private int _imagesCount;
    private int _lastSpawnedImageId = 0;
    private bool _canSpawnFurther = true;

    private void Start()
    {
        StartCoroutine(GetImagesCount());
        ScrollController.OnUserScrolledDown += SpawnPortionOfImages;
    }

    private void OnDestroy()
    {
        ScrollController.OnUserScrolledDown -= SpawnPortionOfImages;
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

                SpawnPortionOfImages();
            }
            else
            {
                Debug.LogError("Server connection failed: " + webRequest.error);
            }
        }
    }

    private void SpawnPortionOfImages()
    {
        if (!_canSpawnFurther)
        {
            return;
        }

        if (_lastSpawnedImageId + _imagesPortionSpawnSize >= _imagesCount)
        {
            _imagesPortionSpawnSize = _imagesCount % 10;
            _canSpawnFurther = false;
        }

        for (int i = _lastSpawnedImageId + 1; i <= _lastSpawnedImageId + _imagesPortionSpawnSize; i++)
        {
            SpawnImage(i);
        }

        _lastSpawnedImageId += _imagesPortionSpawnSize;
    }

    private void SpawnImage(int imageId)
    {
        ImageObject imageObject = Instantiate(_imageObject, _imagesParent);
        imageObject.LoadImage(imageId);
    }
}
