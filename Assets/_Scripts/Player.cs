using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PhysicsMovement))]
[RequireComponent(typeof(KeyboardInput))]
public class Player : MonoBehaviour
{
    [SerializeField] private Transform _spawn;
    [SerializeField] private LayerMask _ground;

    public float LifeTime { get; private set; }

    public event UnityAction<GameResult> OnGameOver;
    public event UnityAction OnLifeTimeChanged;

    private PhysicsMovement _physicsMovement;
    private KeyboardInput _keyboardInput;

    private bool IsGrounded => Physics.Raycast(transform.position, Vector3.down, 10, _ground);

    private void Start()
    {
        enabled = false;

        _physicsMovement = GetComponent<PhysicsMovement>();
        _keyboardInput = GetComponent<KeyboardInput>();
    }

    private void Update()
    {
        LifeTime += Time.deltaTime;
        OnLifeTimeChanged?.Invoke();
    }

    private void FixedUpdate()
    {
        if (IsGrounded)
            _physicsMovement.Move(_keyboardInput.MoveDirection);
    }

    public void GameOver(GameResult gameResult)
    {
        gameObject.SetActive(false);
        _physicsMovement.SetKinematic(true);

        OnGameOver?.Invoke(gameResult);
    }

    public void Respawn()
    {
        transform.position = _spawn.position;

        gameObject.SetActive(true);
        _physicsMovement.SetKinematic(false);

        LifeTime = 0;
    }
}
