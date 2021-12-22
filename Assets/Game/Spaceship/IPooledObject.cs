
using UnityEngine;

public interface IPooledObject
{
    void OnObjectSpawn(Vector3 position, Quaternion rotation, Vector3 targetPoint);
}
