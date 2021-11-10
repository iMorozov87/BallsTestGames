using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallsPull : MonoBehaviour
{
    [SerializeField] private Ball _ballTemplate;
    [SerializeField] private uint _ballsCount;
    [SerializeField] private SpawnPointGeneretor _pointGeneretor;

    private List<Ball> _balls = new List<Ball>();

    public event UnityAction<Ball> BallDied;

    private void Awake()
    {
        for (int i = 0; i < _ballsCount; i++)
        {
            AddNewBall();
        }
    }    

    public Ball GetBall()
    {
        if(TryGetBall(out Ball ball))
        {
            return ball;
        }
        else
        {
            return AddNewBall();
        }

    }
    private bool TryGetBall(out Ball ball)
    {
        foreach (var existingBall in _balls)
        {
            if (existingBall.gameObject.activeSelf == false)
            {
                ball = existingBall;
                return true;
            }
        }
        ball = null;
        return false;
    }  

    private Ball AddNewBall()
    {
        Ball newBall = Instantiate(_ballTemplate, transform);
        newBall.gameObject.SetActive(false);
        newBall.Died += OnBallDied;
        _balls.Add(newBall);
        return newBall;
    }

    private void OnBallDied(Ball ball)
    {
        BallDied?.Invoke(ball);
    }

    private void OnDisable()
    {
        foreach (var ball in _balls)
        {
            ball.Died -= OnBallDied;
        }

    }
}
