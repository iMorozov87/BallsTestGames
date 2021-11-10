using UnityEngine;

public class PlayerHealthDisplay : ValueDisplay
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int health)
    {
        uint clampedHealth = GetClampedHealth(health);
        SetValueText(clampedHealth);
    }

    private uint  GetClampedHealth( int health)
    {
       return (uint)Mathf.Clamp(health, 0, int.MaxValue);
    }
}
