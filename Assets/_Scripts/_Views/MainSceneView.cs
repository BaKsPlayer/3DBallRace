using UnityEngine;
using UnityEngine.Events;

public class MainSceneView : MonoBehaviour
{
    public event UnityAction OnGameStarted;
    public event UnityAction OnShowPreviousResults;

    [SerializeField] private GameObject _noResultsText;

    public void StartGame()
    {
        OnGameStarted?.Invoke();
    }

    public void ShowPreviousResults()
    {
        OnShowPreviousResults?.Invoke();
    }

    public void ShowNoResultsText()
    {
        _noResultsText.SetActive(true);
    }
}
