using System.Collections.Generic;
using UnityEngine;

public class SpawnPointGeneretor : MonoBehaviour
{
    [SerializeField] private CameraBordaries _cameraBordaries;
    [SerializeField] private int _step = 1;
    
    private List<Vector3Int> _spawnPoints = new List<Vector3Int>();

    private void Start()
    {
        CreateSpawnPoints();
    }

    public Vector3Int GetRandomPoint()
    {
        int randomIndex = Random.Range(0, _spawnPoints.Count);
        return _spawnPoints[randomIndex];
    }

    private void CreateSpawnPoints()
    {
        Vector3Int firstPoint = GetFirstPoint(); 
        _spawnPoints.Add(firstPoint);
        Vector3Int lastPoint = firstPoint;       
        float maxPositionX = _cameraBordaries.RightTopBorder.x - _step;
        Generate(firstPoint ,maxPositionX);       
    }

    private Vector3Int GetFirstPoint()
    {
        return Vector3Int.CeilToInt(_cameraBordaries.LeftTopBorder) + Vector3Int.one;
    }

    private void Generate(Vector3Int lastPoint, float maxPositionX)
    {
        bool isGenerating = true;
        while (isGenerating)
        {
            int positionX = lastPoint.x + _step;
            if (positionX < maxPositionX)
            {
                Vector3Int newPoint = new Vector3Int(positionX, lastPoint.y, 0);
                _spawnPoints.Add(newPoint);
                lastPoint = newPoint;
            }
            else
            {
                isGenerating = false;
            }
        }
    }
}
