using System.Collections;
using UnityEngine;

public class LoadingCanvas : MonoBehaviour
{
    [SerializeField] private float _loadingTime;
    [SerializeField] private int _gallerySceneIndex;
    [SerializeField] private LoadingBar _loadingBar;

    private float _currentTime;
    private float _counterValue;

    private void OnEnable()
    {
        StartCoroutine(Count());
    }

    private IEnumerator Count()
    {
        while (_currentTime < _loadingTime)
        {
            float progress = _currentTime / _loadingTime;
            _counterValue = Mathf.RoundToInt(progress * 100);
            _loadingBar.SetLoadingProgress(_counterValue);

            yield return null;

            _currentTime += Time.deltaTime;
        }

        _counterValue = 100;
        EventBus.OnSceneLoadTriggered?.Invoke(_gallerySceneIndex);
    }
}
