using UnityEngine;

public class DeviceOrientationController : MonoBehaviour
{
    [SerializeField] private bool _allowLandscape;

    private void Update()
    {
        SetOrientation();
    }

    private void SetOrientation()
    {
        if (_allowLandscape)
        {
            Screen.orientation = ScreenOrientation.AutoRotation;
            Screen.autorotateToPortrait = true;
            Screen.autorotateToPortraitUpsideDown = true;
            Screen.autorotateToLandscapeLeft = true;
            Screen.autorotateToLandscapeRight = true;
        }
        else
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }
    }
}
