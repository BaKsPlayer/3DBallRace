using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class PlayModeView : MonoBehaviour
{
    [SerializeField] private Text _timerText;

    public void SetTimerAmount(float playerLifetime)
    {
        _timerText.text = playerLifetime.ToTimeSpan().ToString("mm':'ss':'ff");
    }
}

