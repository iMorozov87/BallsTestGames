using UnityEngine;

[System.Serializable]
public class BallParameterUint : BallPapameter<uint>
{
    protected override uint GetRandomValue()
    {
        return (uint)Random.Range(MinValue, MaxValue);
    }
}
