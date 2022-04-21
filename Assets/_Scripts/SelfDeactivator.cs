using UnityEngine;

[RequireComponent(typeof( Animation))]
public class SelfDeactivator : MonoBehaviour
{
    private Animation _animation;

    private void Awake()
    {
        _animation = GetComponent<Animation>();
    }

    private void OnEnable()
    {
        Invoke(nameof(Deactivate), _animation.clip.length);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
