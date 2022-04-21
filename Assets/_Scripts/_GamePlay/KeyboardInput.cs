using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public Vector3 MoveDirection { get; private set; }

    private void Update()
    {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");

        MoveDirection = new Vector3(horizontal, 0, vertical);
    }
}
