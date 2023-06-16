using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
    [SerializeField] private Image _progressBar;
    [SerializeField] private TextMeshProUGUI _loadingPercantage;

    private const string _percentSign = "%";

    public void SetLoadingProgress(float progress)
    {
        _loadingPercantage.text = progress.ToString() + _percentSign;
        _progressBar.fillAmount = progress / 100f;
    }
}
