using UnityEngine;

public class GameOverActivator : MonoBehaviour
{
    [SerializeField] private Menu _menu;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.Died += OnPlayerDied;
    }

    private void OnDisable()
    {
        _player.Died -= OnPlayerDied;
    }

    private void OnPlayerDied()
    {
        _menu.GameOverDisplayActivate();
    }
}
