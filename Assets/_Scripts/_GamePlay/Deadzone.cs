using UnityEngine;

public class Deadzone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
            player.GameOver(Outcome.Loss);
    }
}
