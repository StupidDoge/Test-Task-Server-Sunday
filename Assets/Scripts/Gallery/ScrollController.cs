using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScrollController : MonoBehaviour
{
    public static event Action OnUserScrolledDown;

    [SerializeField] private float _debounceDelay = 0.5f;

    private ScrollRect _scrollRect;
    private bool _isDebouncing = false;

    private void Start()
    {
        _scrollRect = GetComponent<ScrollRect>();
        _scrollRect.onValueChanged.AddListener(OnScroll);
    }

    private void OnScroll(Vector2 scrollPosition)
    {
        if (!_isDebouncing && _scrollRect.verticalNormalizedPosition <= 0f)
        {
            _isDebouncing = true;
            StartCoroutine(DebounceDelay());
            OnUserScrolledDown?.Invoke();
        }
    }

    private IEnumerator DebounceDelay()
    {
        yield return new WaitForSeconds(_debounceDelay);
        _isDebouncing = false;
    }
}
