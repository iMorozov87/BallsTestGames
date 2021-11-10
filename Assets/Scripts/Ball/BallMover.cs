using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball), (typeof(Rigidbody2D)))]
public class BallMover : MonoBehaviour
{
    [SerializeField] private Vector2 _direction = Vector2.down;

    private Ball _ball;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _ball = GetComponent<Ball>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _direction * _ball.Speed * Time.fixedDeltaTime);
    }
}
