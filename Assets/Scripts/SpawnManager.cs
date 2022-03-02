using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _targetPrefab;
    [SerializeField] private float _spawnRangeX;
    [SerializeField] private float _spawnRangeY;
    [SerializeField] private float _startDelay;
    [SerializeField] private GameManager _gameManager;
    
    private float _spawnInterval;

    private void SpawnTarget()
    {
        var randTime = Random.Range(1, 3);
        var randRot = Quaternion.Euler(0, 0, Random.Range(-45, 45));
        var spawnPos = new Vector3(Random.Range(-_spawnRangeX, _spawnRangeX), Random.Range(-_spawnRangeY, _spawnRangeY),
            20f);

        // check if player is alive
        if (_gameManager.IsAlive())
        {
            Instantiate(_targetPrefab, spawnPos, randRot);
            Invoke(nameof(SpawnTarget), randTime);
        }
        else
        {
            CancelInvoke();
            
            foreach (var target in GameObject.FindGameObjectsWithTag("Target"))
            {
                Destroy(target);
            }
        }
    }
}