using System.IO;
using UnityEngine;

public class ResultsPresenter : MonoBehaviour
{
    [SerializeField] private ResultsView _view;
    [SerializeField] private MainSceneView _mainSceneView;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _mainSceneView.OnShowPreviousResults += ShowPreviousResults;
        _player.OnGameOver += GameOver;
    }

    private void OnDisable()
    {
        _mainSceneView.OnShowPreviousResults -= ShowPreviousResults;
        _player.OnGameOver -= GameOver;
    }

    private void GameOver(GameResults results)
    {
        _view.FillResults(results);
        _view.gameObject.SetActive(true);
    }

    public void ShowPreviousResults()
    {
        GameResults results = null;

        if (PlayerPrefs.HasKey("PreviousResults"))
            results = JsonUtility.FromJson<GameResults>(PlayerPrefs.GetString("PreviousResults"));

        if (results == null)
        {
            _mainSceneView.ShowNoResultsText();
            return;
        }

        _mainSceneView.gameObject.SetActive(false);

        _view.FillResults(results, isPreviousResults: true);
        _view.gameObject.SetActive(true);
    }
}
