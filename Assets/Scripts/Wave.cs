using System.Collections;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [Header("Wave Settings")]
    public GameObject enemyPrefab;
    public int enemyCount;
    public float TimeAfterLastSpawn = 2f; // Time to wait after the last enemy is spawned before starting the next wave
    public SimpleEnemyMoveData moveData;
    public float TimeBetweenSpawns = 0.2f; // Adjust as needed

    void Start()
    {

        StartCoroutine(SpawnEnemies());



    }


    private IEnumerator SpawnEnemies()
    {
        if (enemyCount <= 0)
        {
            Debug.LogWarning("Enemy count must be greater than 0.");
            yield break;
        }
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy(enemyPrefab);
            yield return new WaitForSeconds(TimeBetweenSpawns); // Adjust the delay as needed
        }
        // Notify LevelManager that this wave is complete
        yield return new WaitForSeconds(TimeAfterLastSpawn); // Wait after the last enemy is spawned
        LevelManager.Instance.StartNextWave();
        // Destroy this wave object after spawning all enemies
        Destroy(gameObject);
    }

    private void SpawnEnemy(GameObject enemy)
    {
        GameObject enemyInstance = Instantiate(enemy);
        if (enemyInstance.TryGetComponent<EnemyMovement>(out var enemyMovement))
        {
            enemyMovement.SetMoveData(moveData);
        }
    }
}
