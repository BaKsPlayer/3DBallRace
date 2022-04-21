using UnityEngine;
using UnityEngine.UI;

public class PlayModeView : MonoBehaviour
{
    [SerializeField] private Text _timerText;
    [SerializeField] private Text _startGameAnimationText;

    private void OnEnable()
    {
        _startGameAnimationText.gameObject.SetActive(true);
    }

    public void SetTimerAmount(float playerLifetime)
    {
        _timerText.text = playerLifetime.ToTimeSpan().ToString("mm':'ss':'ff");
    }

    public void SetStartGameAnimationText(string value)
    {
        _startGameAnimationText.text = value;
    }
}

