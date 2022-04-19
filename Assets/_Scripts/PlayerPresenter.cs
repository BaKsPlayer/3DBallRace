using UnityEngine;

public class PlayerPresenter : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private MainSceneView _mainSceneView;
    [SerializeField] private ResultsView _resultsView;
    [SerializeField] private PlayModeView _playModeView;

    private void OnEnable()
    {
        _mainSceneView.OnGameStarted += GameStarted;

        _player.OnGameOver += GameOver;
        _player.OnLifeTimeChanged += LifetimeChanged;
    }

    private void OnDisable()
    {
        _mainSceneView.OnGameStarted -= GameStarted;

        _player.OnGameOver -= GameOver;
        _player.OnLifeTimeChanged -= LifetimeChanged;
    }

    private void GameStarted()
    {
        _player.enabled = true;
        _player.Respawn();

        _playModeView.gameObject.SetActive(true);
    }

    private void GameOver(GameResult result)
    {
        _player.enabled = false;

        _resultsView.FillResults(result, _player.LifeTime);
        _resultsView.gameObject.SetActive(true);

        _playModeView.gameObject.SetActive(false);
    }

    private void LifetimeChanged()
    {
        _playModeView.SetTimerAmount(_player.LifeTime);
    }
}
