using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    public event UnityAction Died;
    public event UnityAction<int> HealthChanged;

    private void Start()
    {
        HealthChanged?.Invoke(_health);
    }

    public void ApplyDamage(uint demage)
    {
        _health -= (int)demage;
        HealthChanged?.Invoke(_health);
        if (_health <= 0)
        {
            Died?.Invoke();
        }
    }
}
