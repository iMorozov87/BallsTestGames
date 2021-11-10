using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _health;
    [SerializeField] private uint _reward;
    [SerializeField] private uint _damage;

    public float Speed => _speed;
    public int Health => _health;
    public uint Reward => _reward;
    public uint Damage => _damage;

    public event UnityAction<Ball> Inited;
    public event UnityAction<Ball> DamageApplied;
    public event UnityAction<Ball> Died;

    public void Init(float speed, uint health, uint reward, uint damage)
    {
        _speed = speed;
        _health = (int)health;
        _reward = reward;
        _damage = damage;
        Inited?.Invoke(this);
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        DamageApplied?.Invoke(this);
        {
            if (_health <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        Died?.Invoke(this);
        gameObject.SetActive(false);
    }
}
