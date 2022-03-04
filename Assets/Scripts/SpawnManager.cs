using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _targetPrefab = new List<GameObject>();
    [SerializeField] private float _spawnRangeX;
    [SerializeField] private float _spawnRangeY;
    [SerializeField] private float _startDistance;

    private float _spawnInterval;

    public void SpawnTarget()
    {
        var randTime = Random.Range(1, 5);
        var randTarget = Random.Range(0, _targetPrefab.Count);
        var randRot = Quaternion.Euler(0, 0, Random.Range(-45, 45));
        var spawnPos = new Vector3(Random.Range(-_spawnRangeX, _spawnRangeX), Random.Range(-_spawnRangeY, _spawnRangeY),
            _startDistance);

        Instantiate(_targetPrefab[randTarget], spawnPos, randRot);
        Invoke(nameof(SpawnTarget), randTime);
    }

    public void DestroySpawnedTargets()
    {
        foreach (var target in GameObject.FindGameObjectsWithTag("Target"))
        {
            Destroy(target);
        }
    }
}