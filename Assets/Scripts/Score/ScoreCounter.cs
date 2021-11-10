using UnityEngine;
using UnityEngine.Events;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private BallsPull _ballsPull;
    [SerializeField] private Player _player;

    private uint _score = 0;
    private uint _bestScore;

    public event UnityAction<uint> ScoreChanged;
    public event UnityAction<uint> BestScoreChanged;

    private void Start()
    {        
        _bestScore = DataSaver.Load(nameof(_bestScore));
        BestScoreChanged?.Invoke(_bestScore);
    }

    private void OnEnable()
    {
        _ballsPull.BallDied += OnBallDied;
        _player.Died += OnPlayerDied;
    }

    private void OnDisable()
    {
        _ballsPull.BallDied -= OnBallDied;
        _player.Died -= OnPlayerDied;
    }

    private void OnPlayerDied()
    {
        TrySetBestScore();
    }

    private void TrySetBestScore()
    {
        if (_score > _bestScore)
        {
            SetBestScore(_score);
        }
    }

    private void SetBestScore(uint score)
    {
        _bestScore = score;
        DataSaver.Save(nameof(_bestScore), _bestScore);      
        BestScoreChanged?.Invoke(_bestScore);
    }

    private void OnBallDied(Ball ball)
    {
        AddScore(ball);
    }

    private void AddScore(Ball ball)
    {
        _score += ball.Reward;
        ScoreChanged?.Invoke(_score);
    }
}
