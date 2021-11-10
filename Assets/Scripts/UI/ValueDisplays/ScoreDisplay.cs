using UnityEngine;

public class ScoreDisplay : ValueDisplay
{
    [SerializeField] private ScoreCounter _scoreCounter;

    private void OnEnable()
    {
        _scoreCounter.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _scoreCounter.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(uint score)
    {
        SetValueText(score);
    }
}
