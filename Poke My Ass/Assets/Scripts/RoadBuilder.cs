using System.Collections.Generic;
using UnityEngine;

public class RoadBuilder
{
    private TablePool _pool = new TablePool();
    private Queue<GameObject> _roads = new Queue<GameObject>();
    private RoadBundle _roadPrefabs;
    private Transform _lastRoadTransform;

    private readonly float _minDistanceBetweenLastRoadAndPlayer;
    private readonly int _maxRoads;

    public RoadBuilder(Vector3 positionFirstRoad, float distanceBetweenLastRoadAndPlayer, int maxRoads)
    {
        _roadPrefabs = Resources.Load<RoadBundle>("RoadBundle");
        _minDistanceBetweenLastRoadAndPlayer = distanceBetweenLastRoadAndPlayer;
        _maxRoads = maxRoads;
        var road = CreateRoad(positionFirstRoad, _roadPrefabs.GetPrefab(0));
        RefreshLastRoad(road);
    }

    public void HandlePosition(float z)
    {
        while (_lastRoadTransform.position.z - z < _minDistanceBetweenLastRoadAndPlayer)
        {
            var prefab = _roadPrefabs.GetRandomPrefab();
            var position = _lastRoadTransform.position;
            position.z = position.z + (_lastRoadTransform.localScale + prefab.transform.localScale).z / 2f;
            var road = CreateRoad(position, prefab);
            RefreshLastRoad(road);
            RemoveObsoleteRoads();
        }
    }

    private GameObject CreateRoad(Vector3 position, GameObject prefab)
    {
        var road = _pool.Spawn(prefab);
        road.transform.position = position;
        return road;
    }

    private void RefreshLastRoad(GameObject road)
    {
        _lastRoadTransform = road.transform;
        _roads.Enqueue(road);
    }

    private void RemoveObsoleteRoads()
    {
        while (_roads.Count > _maxRoads)
        {
            _pool.Despawn(_roads.Dequeue());
        }
    }
}
