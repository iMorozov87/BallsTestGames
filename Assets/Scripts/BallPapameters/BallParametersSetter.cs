using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallParametersSetter : MonoBehaviour
{
    [SerializeField] private BallParameterFloat _speed;
    [SerializeField] private BallParameterUint _health;
    [SerializeField] private BallParameterUint _reward;
    [SerializeField] private BallParameterUint _damage;
    [SerializeField] private BallParameterColor _color;

    public void SetBall(Ball ball)
    {  
        ball.Init(_speed.Value, _health.Value, _reward.Value, _damage.Value);
        BallVisualisator visualisator = ball.GetComponent<BallVisualisator>();
        visualisator.SetColor(_color.Value);
    }
}
