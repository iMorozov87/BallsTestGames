using TMPro;
using UnityEngine;

public class ValueDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _valueText;

    protected void SetValueText(uint value)
    {
        _valueText.text = value.ToString();
    }    
}
