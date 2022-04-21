using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PhysicsMovement))]
[RequireComponent(typeof(KeyboardInput))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayModeView _view;
    [SerializeField] private Transform _spawn;
    [SerializeField] private LayerMask _ground;

    public float Lifetime { get; private set; }

    public event UnityAction<GameResults> OnGameOver;
    public event UnityAction OnLifeTimeChanged;

    private PhysicsMovement _physicsMovement;
    private KeyboardInput _keyboardInput;

    private bool IsGrounded => Physics.Raycast(transform.position, Vector3.down, 10, _ground);

    private void Start()
    {
        enabled = false;
        gameObject.SetActive(false);

        _physicsMovement = GetComponent<PhysicsMovement>();
        _keyboardInput = GetComponent<KeyboardInput>();
    }

    private void Update()
    {
        Lifetime += Time.deltaTime;
        OnLifeTimeChanged?.Invoke();
    }

    private void FixedUpdate()
    {
        if (IsGrounded)
            _physicsMovement.Move(_keyboardInput.MoveDirection);
    }

    public void GameOver(Outcome outcome)
    {
        gameObject.SetActive(false);
        _physicsMovement.SetKinematic(true);

        var results = CreateGameResults(outcome);
        OnGameOver?.Invoke(results);

        Lifetime = 0;
        OnLifeTimeChanged?.Invoke();

        enabled = false;
        _view.gameObject.SetActive(false);
    }

    public void Respawn()
    {
        transform.position = _spawn.position;

        gameObject.SetActive(true);
        _physicsMovement.SetKinematic(false);
    }

    private GameResults CreateGameResults(Outcome outcome)
    {
        var resultsAsset = new GameResults();

        resultsAsset.SetLifetime(Lifetime);
        resultsAsset.SetOutcome(outcome);

        PlayerPrefs.SetString("PreviousResults", JsonUtility.ToJson(resultsAsset));

        return resultsAsset;
    }
}
