using UnityEngine;

[RequireComponent(typeof(SpawnPointGeneretor), typeof(BallsPull), typeof(BallParametersSetter))]
public class BallsSpawner : MonoBehaviour
{
    private SpawnPointGeneretor _pointGeneretor;
    private BallsPull _ballsPull;
    private BallParametersSetter _parametersSetter;

    private void Awake()
    {
        _ballsPull = GetComponent<BallsPull>();
        _pointGeneretor = GetComponent<SpawnPointGeneretor>();
        _parametersSetter = GetComponent<BallParametersSetter>();
    }

    public void Spawn()
    {
        Ball ball = _ballsPull.GetBall();
        ActivateBall(ball);
        SetBallPosition(ball);
        SetBallParameters(ball);
    }

    private void ActivateBall(Ball ball)
    {
        ball.gameObject.SetActive(true);
    }

    private void SetBallPosition(Ball ball)
    {
        ball.transform.position = _pointGeneretor.GetRandomPoint();       
    }

    private void SetBallParameters(Ball ball)
    {
        _parametersSetter.SetBall(ball);
    }
}
