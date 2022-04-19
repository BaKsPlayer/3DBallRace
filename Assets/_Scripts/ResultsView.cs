using UnityEngine;
using UnityEngine.UI;

public class ResultsView : MonoBehaviour
{
    [SerializeField] private Text _resultText;
    [SerializeField] private Text _timerText;

    [SerializeField] private GameObject _previousResultsWarning;

    [SerializeField] private Color _victoryColor;
    [SerializeField] private Color _lossColor;

    public void FillResults(GameResult result, float playerLifetime, bool isPreviousResults = false)
    {
        string resultText = string.Empty;
        Color resultColor = Color.white;

        switch (result)
        {
            case GameResult.Victory:
                resultText = "ВЫ ВЫИГРАЛИ! :)";
                resultColor = _victoryColor;
                break;

            case GameResult.Loss:
                resultText = "ВЫ ПРОИГРАЛИ! :(";
                resultColor = _lossColor;
                break;

            default:
                throw new System.NotImplementedException();
        }

        _resultText.text = resultText;
        _resultText.color = resultColor;

        _timerText.text = playerLifetime.ToTimeSpan().ToString("mm':'ss':'ff");

        _previousResultsWarning.SetActive(isPreviousResults);
    }
}
