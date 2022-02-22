using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _spherePrefab;
    [SerializeField] private float _spawnRangeX;
    [SerializeField] private float _spawnRangeY;
    [SerializeField] private float _startDelay;

    private float _spawnInterval;

    private void Start()
    {
        Invoke(nameof(SpawnSphere), 0.5f);
    }

    private void SpawnSphere()
    {
        var randTime = Random.Range(1, 3);
        var randRot = Quaternion.Euler(0, 0, Random.Range(-45, 45));
        var spawnPos = new Vector3(Random.Range(-_spawnRangeX, _spawnRangeX), Random.Range(-_spawnRangeY, _spawnRangeY),
            20f);
        Instantiate(_spherePrefab, spawnPos, randRot);

        Invoke(nameof(SpawnSphere), randTime);
    }
}