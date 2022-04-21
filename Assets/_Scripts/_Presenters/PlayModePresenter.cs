using UnityEngine;

public class PlayModePresenter : MonoBehaviour
{
    [SerializeField] private PlayModeView _view;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.OnLifeTimeChanged += LifetimeChanged;
    }

    private void OnDisable()
    {
        _player.OnLifeTimeChanged -= LifetimeChanged;
    }

    private void LifetimeChanged()
    {
        _view.SetTimerAmount(_player.Lifetime);
    }

}
