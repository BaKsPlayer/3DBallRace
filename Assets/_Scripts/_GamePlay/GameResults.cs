using UnityEngine;

public class GameResults
{
    public static readonly string DataPath;

    [SerializeField] private Outcome _outcome;
    public Outcome Outcome => _outcome;

    [SerializeField] private float _lifetime;
    public float Lifetime => _lifetime;

    static GameResults()
    {
#if UNITY_EDITOR
        DataPath = $"Assets/StreamingAssets/GameResults.json";
#else
        DataPath = $"{Application.persistentDataPath}/StreamingAssets/GameResults.json";
#endif
    }

    public void SetLifetime(float value)
    {
        _lifetime = value;
    }

    public void SetOutcome(Outcome value)
    {
        _outcome = value;
    }
}
