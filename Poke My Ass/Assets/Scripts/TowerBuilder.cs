using UnityEngine;

public class TowerBuilder
{
    private GameObject _prefabTower;
    private int _countTower = -1;

    public TowerBuilder()
    {
        _prefabTower = Resources.Load<GameObject>("Tower");
    }

    public void HandlePosition(float z)
    {
        if(z > _countTower * 600)
        {
            Object.Instantiate(_prefabTower, new Vector3(-30, -60, ++_countTower * 600), Quaternion.identity);
        }
    }
}
