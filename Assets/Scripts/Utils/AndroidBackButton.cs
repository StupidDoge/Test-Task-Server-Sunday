using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidBackButton : MonoBehaviour
{
    [SerializeField] private int _previousSceneId;

#if PLATFORM_ANDROID
    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android && Input.GetKeyDown(KeyCode.Escape))
        {
            SceneLoader.Instance.LoadSceneAsync(_previousSceneId);
        }
    }
#endif
}
