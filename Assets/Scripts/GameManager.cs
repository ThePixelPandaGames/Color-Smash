using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private EnemySpawnManager enemySpawnManager;
    private ScoreManager scoreManager;
    private TimeManager timeManager;
    private SpecialEffectFactory specialEffectFactory;

    [SerializeField] private float levelUpIntervall = 10;

    public float enemyMoveSpeed = 3;
    public float enemyMoveSpeedMultiplier = 1.1f;


    public float spawnIntervallDivider = 1.25f;
    public float startIntervall = 2;

    private float startIntervallGap = 1;

    public float SpawnEffectIntervall = 5;
    [HideInInspector]public bool isEffectSlotFree = true;


    [HideInInspector]public SpecialEffect availableSpecialEffect;

    public SpriteRenderer effectRenderer;


    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        enemySpawnManager = GetComponent<EnemySpawnManager>();  
        scoreManager = GetComponent<ScoreManager>();
        timeManager = GetComponent<TimeManager>();  
        specialEffectFactory = GetComponent<SpecialEffectFactory>();    



        InvokeRepeating(nameof(LevelUp), startIntervallGap, levelUpIntervall);


        InvokeRepeating(nameof(CreateNewSpecialEffect), 5, SpawnEffectIntervall);

        enemySpawnManager.StartSpawn(startIntervall, enemyMoveSpeed);
       
    }

    public void CreateNewSpecialEffect()
    {
        if (isEffectSlotFree)
        {
            availableSpecialEffect = specialEffectFactory.CreateRandomEffect();
            effectRenderer.sprite = specialEffectFactory.effectImage;
            isEffectSlotFree = false;
        }
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

    public void HalfEnemySpeed(int cooldown)
    {
        StartCoroutine(HalfEnemySpeedCo(cooldown));
    }

    public void HalfClockTime(int cooldown)
    {
        StartCoroutine(HalfClockTimeCo(cooldown));

    }

    IEnumerator HalfEnemySpeedCo(int cooldown)
    {
        // get all enemies in scene
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies) {
            enemy.GetComponent<EnemyMovement>().moveSpeed = enemyMoveSpeed / 2;
        }

        enemySpawnManager.EnemySpeed = enemyMoveSpeed / 2;

        while (cooldown > 0)
        {
            cooldown--;
            yield return new WaitForSecondsRealtime(1);
        }
        
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyMovement>().moveSpeed = enemyMoveSpeed;
        }
        enemySpawnManager.EnemySpeed = enemyMoveSpeed;
        isEffectSlotFree = true;


    }

    IEnumerator HalfClockTimeCo(int cooldown)
    {
        timeManager.secondsToWait *= 2;

        while (cooldown > 0)
        { 
            cooldown--;

            yield return new WaitForSecondsRealtime(1);
        }
        timeManager.secondsToWait /= 2;

        isEffectSlotFree = true;
    }






}
