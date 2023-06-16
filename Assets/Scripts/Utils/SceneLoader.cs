using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void OnEnable()
    {
        EventBus.OnSceneLoadTriggered += LoadSceneAsync;
    }

    private void OnDisable()
    {
        EventBus.OnSceneLoadTriggered -= LoadSceneAsync;
    }

    private void LoadSceneAsync(int sceneIndex)
    {
        SceneManager.LoadSceneAsync(sceneIndex);
    }
}
