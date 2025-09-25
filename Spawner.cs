using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float _spawnTimer;
    private float _spawnInterval = 1f;
    // serialize field makes it visible in the inspector but private in code
    [SerializeField] private ObjectPooler pool;

    void Update()
    { // spawn enemy every second
        _spawnTimer -= Time.deltaTime;
        if (_spawnTimer <= 0)
        {
            _spawnTimer = _spawnInterval;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    { // get object from pool and set its position to spawner's position
        GameObject spawnedObject = pool.GetPooledObject();
        spawnedObject.transform.position = transform.position;
        spawnedObject.SetActive(true);
    }
}
