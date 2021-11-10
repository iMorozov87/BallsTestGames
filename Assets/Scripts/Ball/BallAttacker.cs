using UnityEngine;

[RequireComponent(typeof(Ball))]
public class BallAttacker : MonoBehaviour
{
    private Ball _ball;

    private void Awake()
    {
        _ball = GetComponent<Ball>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            player.ApplyDamage(_ball.Damage);
        }
    }
}
