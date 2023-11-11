using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private EnemySpawnManager enemySpawnManager;
    private ScoreManager scoreManager;

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

        enemySpawnManager = GetComponent<EnemySpawnManager>();  
        scoreManager = GetComponent<ScoreManager>();



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

    public void IncreaseScoreByOne ()
    {
        scoreManager.IncreaseScoreByOne();
    }


}
