using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BallParameterColor : BallPapameter<Color>
{
    protected override Color GetRandomValue()
    {
        return new Color(GetRandomСolorСhannel(), GetRandomСolorСhannel(), GetRandomСolorСhannel());
    }

    private float GetRandomСolorСhannel()
    {
        float channelValue = Random.Range(0, 1f);
        return channelValue;
    }
}
