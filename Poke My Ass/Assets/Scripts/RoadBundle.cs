using UnityEngine;

[CreateAssetMenu(fileName = "RoadBundle", menuName = "PokeMyAss/RoadBundle")]
public class RoadBundle : ScriptableObject
{
    [SerializeField] private GameObject[] _prefabs;

    public GameObject GetPrefab(int index)
    {
        return _prefabs[index];
    }

    public GameObject GetRandomPrefab()
    {
        return GetPrefab(Random.Range(0, _prefabs.Length));
    }
}
