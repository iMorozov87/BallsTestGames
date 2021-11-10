using UnityEngine;

public class BestScoreDisplay : ValueDisplay
{
    [SerializeField] private ScoreCounter _scoreCounter;

    private void OnEnable()
    {
        _scoreCounter.BestScoreChanged += OnBestScoreChanged;
    }

    private void OnDisable()
    {
        _scoreCounter.BestScoreChanged -= OnBestScoreChanged;
    }

    private void OnBestScoreChanged(uint score)
    {
        SetValueText(score);
    }
}
