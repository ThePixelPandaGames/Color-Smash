using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public EnemySpawnManager Instance;

    [SerializeField]
    GameObject EnemyPrefab;

    public float spawnIntervall = 1;
    float startSpawn = 1;

    [SerializeField] float xLimit, yLimit;


    void Start()
    {
        if (Instance == null) Instance = this;

        InvokeRepeating(nameof(SpawnEnemyPrefab), startSpawn, spawnIntervall);
    }

    void Update()
    {
        // not needed until now 
    }


    void SpawnEnemyPrefab()
    {
        Vector2 randomSpawnPosition = GetRandomPosition(xLimit, yLimit);
        Instantiate(EnemyPrefab, randomSpawnPosition, Quaternion.identity);
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

}
