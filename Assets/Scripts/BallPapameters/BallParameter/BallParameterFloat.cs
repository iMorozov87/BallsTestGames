using UnityEngine;

[System.Serializable]
public class BallParameterFloat : BallPapameter<float>
{
    protected override float GetRandomValue()
    {
        return Random.Range(MinValue, MaxValue);
    }
}
