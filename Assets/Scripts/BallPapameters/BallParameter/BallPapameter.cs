using UnityEngine;

public abstract class BallPapameter<T>
{
    [SerializeField] private T _minValue;
    [SerializeField] private T _maxValue;

    public T Value => GetRandomValue();
    public T MinValue => _minValue;
    public T MaxValue => _maxValue;

    protected abstract T GetRandomValue();
}
