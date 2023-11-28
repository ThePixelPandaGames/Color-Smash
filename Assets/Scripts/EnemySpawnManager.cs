using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject EnemyPrefab;

    [HideInInspector] public float spawnIntervall;

    [SerializeField] float xLimit, yLimit;


    private float enemySpeed;

    [HideInInspector]public float EnemySpeed { get => enemySpeed; set => enemySpeed = value; }

    void SpawnEnemyPrefab()
    {
        Vector2 randomSpawnPosition = GetRandomPosition(xLimit, yLimit);
        GameObject enemy_go = Instantiate(EnemyPrefab, randomSpawnPosition, Quaternion.identity);
        EnemyMovement enemyMovement = enemy_go.GetComponent<EnemyMovement>();
        enemyMovement.moveSpeed *= EnemySpeed;
    }


    Vector2 GetRandomPosition(float xLimit, float yLimit)
    {
        int random = Random.Range(0, 3);

        switch (random)
        {
            case 0:
                {
                    return new Vector2(Random.Range(-xLimit, xLimit), yLimit);
                }
            case 1:
                {
                    return new Vector2(Random.Range(-xLimit, xLimit), -yLimit);
                }
            case 2:
                {
                    return new Vector2(xLimit, Random.Range(-yLimit, yLimit));
                }

            default: return new Vector2(-xLimit, Random.Range(-yLimit, yLimit));

        }
    }



    public void StartSpawn(float newIntervall, float waitBeforeSpawn, float newEnemySpeed)
    {
        spawnIntervall = newIntervall;
        EnemySpeed = newEnemySpeed;
        InvokeRepeating(nameof(SpawnEnemyPrefab), waitBeforeSpawn, spawnIntervall);
    }

}
