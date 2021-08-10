using System.Collections.Generic;
using UnityEngine;

public class TablePool
{
    private Dictionary<string, Stack<GameObject>> _objectPool = new Dictionary<string, Stack<GameObject>>();

    public GameObject Spawn(GameObject prefab)
    {
        GameObject result;

        if(_objectPool.TryGetValue(prefab.name, out var value) && value.Count > 0)
        {
            result = value.Pop();
            result.SetActive(true);
        }
        else
        {
            result = Object.Instantiate(prefab);
            result.name = prefab.name;
        }

        return result;
    }

    public void Despawn(GameObject prefab)
    {
        if(!_objectPool.TryGetValue(prefab.name, out var value))
        {
            _objectPool[prefab.name] = new Stack<GameObject>();
        }

        prefab.SetActive(false);
        _objectPool[prefab.name].Push(prefab);
    }
}
