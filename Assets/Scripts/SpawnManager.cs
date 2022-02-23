using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _spherePrefab;
    [SerializeField] private float _spawnRangeX;
    [SerializeField] private float _spawnRangeY;
    [SerializeField] private float _startDelay;
    [SerializeField] private GameManager _gameManager;

    private float _spawnInterval;

    private void Start()
    {
        Invoke(nameof(SpawnTarget), 0.5f);
    }

    private void SpawnTarget()
    {
        var randTime = Random.Range(1, 3);
        var randRot = Quaternion.Euler(0, 0, Random.Range(-45, 45));
        var spawnPos = new Vector3(Random.Range(-_spawnRangeX, _spawnRangeX), Random.Range(-_spawnRangeY, _spawnRangeY),
            20f);
        var newTarget = Instantiate(_spherePrefab, spawnPos, randRot);


        // check if player is alive
        if (_gameManager.isAlive())
        {
            Invoke(nameof(SpawnTarget), randTime);
        }
        else
        {
            // optimize stop new spawned hands from moving
            foreach (var target in GameObject.FindGameObjectsWithTag("Target"))
            {
                Destroy(target);
            }
            CancelInvoke();

            
        }
    }
}