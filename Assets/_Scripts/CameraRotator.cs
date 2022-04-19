using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Transform _transform;

    private bool isRotatingAround;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
            isRotatingAround = !isRotatingAround;

        if (isRotatingAround)
        _transform.Rotate(0, _speed * Time.deltaTime, 0);
        else
        {

        }
       
    }


}
