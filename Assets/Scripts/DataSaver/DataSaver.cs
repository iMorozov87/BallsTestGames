using UnityEngine;

public class DataSaver : MonoBehaviour
{
    public static void Save(string saveble, uint value)
    {
        PlayerPrefs.SetInt(saveble, (int)value);
    }

    public static uint Load(string loadeble)
    {
        return (uint)PlayerPrefs.GetInt(loadeble, 0);
    }
}
