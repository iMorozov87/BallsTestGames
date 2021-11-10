using UnityEngine;

[RequireComponent(typeof(Ball))]
public class BallVisualisator : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private ParticleSystem _ballDiedEffectTemplate;
    [SerializeField] private ParticleSystem _ballDamageEffectTemplate;
    [SerializeField] private TextMesh _rewardText;

    private Ball _ball;
    private Color _color;

    private void Awake()
    {
        _ball = GetComponent<Ball>();
    }

    private void OnEnable()
    {
        _ball.Died += OnBallDied;
        _ball.Inited += OnBallInited;
        _ball.DamageApplied += OnDamageApplied;
    }

    private void OnDisable()
    {
        _ball.Died -= OnBallDied;
        _ball.Inited -= OnBallInited;
        _ball.DamageApplied -= OnDamageApplied;
    }

    public void SetColor(Color color)
    {
        _color = color;
        _spriteRenderer.color = color;
    }

    private void OnBallDied(Ball ball)
    {
        PlayEffect(_ballDiedEffectTemplate);
    }

    public void PlayEffect(ParticleSystem effectTemplate)
    {
        ParticleSystem ballEffect = Instantiate(effectTemplate, transform.position, Quaternion.identity);
        var main = ballEffect.main;
        main.startColor = _color;
    }

    private void OnBallInited(Ball ball)
    {
        SetRewardText(ball);
    }

    private void SetRewardText(Ball ball)
    {
        _rewardText.text = ball.Reward.ToString();
    }
    private void  OnDamageApplied(Ball ball)
    {
        PlayEffect(_ballDamageEffectTemplate);
    }
}
