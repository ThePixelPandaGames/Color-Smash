using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private EnemySpawnManager enemySpawnManager;

    [SerializeField] private float levelUpIntervall = 10;

    public float enemyMoveSpeed = 3;
    public float enemyMoveSpeedMultiplier = 1.1f;


    public float spawnIntervallDivider = 1.25f;
    public float startIntervall = 2;

    private float startIntervallGap = 1;



    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        GameObject enemySpawnManager_go = GameObject.Find("Enemy Spawn Manager");

        if (enemySpawnManager != null ) {
            throw new System.Exception("Enemy Spawn Manager not found");
        }

        enemySpawnManager = enemySpawnManager_go.GetComponent<EnemySpawnManager>();

        InvokeRepeating(nameof(LevelUp), startIntervallGap, levelUpIntervall);


        enemySpawnManager.StartSpawn(startIntervall, enemyMoveSpeed);
       
    }


    public void LevelUp()
    {
        Debug.Log("Level up");
        enemySpawnManager.CancelInvoke();

        enemySpawnManager.spawnIntervall /= spawnIntervallDivider;

        enemyMoveSpeed *= enemyMoveSpeedMultiplier;

        enemySpawnManager.StartSpawn(enemySpawnManager.spawnIntervall, enemyMoveSpeed);
    }


}
