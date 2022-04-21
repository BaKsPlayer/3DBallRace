using UnityEngine;
using UnityEngine.UI;

public class ResultsView : MonoBehaviour
{
    [SerializeField] private Text _outcomeText;
    [SerializeField] private Text _timerText;

    [SerializeField] private GameObject _previousResultsWarning;

    [SerializeField] private Color _victoryColor;
    [SerializeField] private Color _lossColor;

    public void FillResults(GameResults results, bool isPreviousResults = false)
    {
        string resultText = string.Empty;
        Color resultColor = Color.white;

        switch (results.Outcome)
        {
            case Outcome.Victory:
                resultText = "ВЫ ВЫИГРАЛИ! :)";
                resultColor = _victoryColor;
                break;

            case Outcome.Loss:
                resultText = "ВЫ ПРОИГРАЛИ! :(";
                resultColor = _lossColor;
                break;

            default:
                throw new System.NotImplementedException();
        }

        _outcomeText.text = resultText;
        _outcomeText.color = resultColor;

        _timerText.text = results.Lifetime.ToTimeSpan().ToString("mm':'ss':'ff");

        _previousResultsWarning.SetActive(isPreviousResults);
    }
}
