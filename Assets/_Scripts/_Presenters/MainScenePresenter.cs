using System.Collections;
using UnityEngine;

public class MainScenePresenter : MonoBehaviour
{
    [SerializeField] private MainSceneView _view;
    [SerializeField] private PlayModeView _playModeView;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _view.OnGameStarted += GameStarted;
    }

    private void OnDisable()
    {
        _view.OnGameStarted -= GameStarted;
    }

    private void GameStarted()
    {
        _playModeView.gameObject.SetActive(true);
        _view.gameObject.SetActive(false);
        StartCoroutine(LaunchStartGameAnimation());
    }

    private IEnumerator LaunchStartGameAnimation()
    {
        float remainingTime = 3f;

        while (remainingTime >= 0)
        {
            remainingTime -= Time.deltaTime;
            _playModeView.SetStartGameAnimationText(Mathf.CeilToInt(remainingTime).ToString());
            yield return null;
        }

        _playModeView.SetStartGameAnimationText("GO!");

        _player.enabled = true;
        _player.Respawn();
    }
}
