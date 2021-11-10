using System.Collections;
using UnityEngine;

public class DifficultyGameSetter : MonoBehaviour
{
    [SerializeField] private BallsSpawner _ballsSpawner;
    [SerializeField] private float _spawnDelay = 3F;
    [SerializeField] private float _delayChangedStep = 0.2f;
    [SerializeField] private float _minSpawnDelay = 1f;
    [SerializeField] private int _maxSpawnCount = 10;

    private int _spawnCount = 0;

    private void Start()
    {
        StartCoroutine(WaitForNextSpawn());
    }

    private IEnumerator WaitForNextSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnDelay);
            ++_spawnCount;
            _ballsSpawner.Spawn();
            if (_spawnDelay > _minSpawnDelay)
            {
                TrySetSpawnDelay();
            }
        }
    }

    private void TrySetSpawnDelay()
    {
        if (_spawnCount >= _maxSpawnCount)
        {
            _spawnCount = 0;
            _spawnDelay -= _delayChangedStep;
        }
    }
}
