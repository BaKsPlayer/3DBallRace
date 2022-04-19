using UnityEngine;
using UnityEngine.Events;

public class MainSceneView : MonoBehaviour
{
    public event UnityAction OnGameStarted;

    public void StartGame()
    {
        gameObject.SetActive(false);
        OnGameStarted?.Invoke();
    }
}
