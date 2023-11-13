using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private EnemySpawnManager enemySpawnManager;
    private ScoreManager scoreManager;
    private TimeManager timeManager;
    private SpecialEffectFactory specialEffectFactory;
    private ColorWheel colorWheel;
    private GameOverLogic gameOverLogic;



    // enemy spawn
    public float enemyMoveSpeed;
    public float enemyMoveSpeedMultiplier;
    public float enemySpawnStartIntervall;


    // level up modifier
    [SerializeField] private float levelUpIntervall = 10;
    public float levelUpSpawnIntervallDivider;
    public float waitForFirstLevelUp;



    // special effects
    public float effectFade;
    public float effectSpawnEffectIntervall;
    public float waitForFirstSpecialEffectSpawn;

    public float destroyEffectRange = 3;




    [HideInInspector] public bool isEffectSlotFree = true;
    [HideInInspector] public bool duringEffect = false;
    [HideInInspector] public bool isPaused = false;
    [HideInInspector] public SpecialEffect availableSpecialEffect;
    public SpriteRenderer effectRenderer;
    [HideInInspector] public bool isRainbowEffectActivated = false;
    [HideInInspector] public bool isGameOver = false;

    public GameObject highScoreUI;
    


    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        // maybe necessary?
        Time.timeScale = 1;


        enemySpawnManager = GetComponent<EnemySpawnManager>();
        scoreManager = GetComponent<ScoreManager>();
        timeManager = GetComponent<TimeManager>();
        specialEffectFactory = GetComponent<SpecialEffectFactory>();
        gameOverLogic = GetComponent<GameOverLogic>();  
        colorWheel = GameObject.Find("Color Wheel").GetComponent<ColorWheel>(); 



        InvokeRepeating(nameof(LevelUp), waitForFirstLevelUp, levelUpIntervall);


        InvokeRepeating(nameof(CreateNewSpecialEffect), waitForFirstSpecialEffectSpawn, effectSpawnEffectIntervall);


        enemySpawnManager.StartSpawn(enemySpawnStartIntervall, enemyMoveSpeed);


        ApplySettings();

    }

    private void ApplySettings()
    {
        //  music

        //  sfx

        Debug.Log(SettingsManager.currentSettings.rotationSensitivity);
        colorWheel.rotSpeedMultiplier = SettingsManager.currentSettings.rotationSensitivity;
    }


    public void OnGameOver()
    {
        isGameOver = true;
        CancelInvoke();
        StopAllCoroutines();
        timeManager.timeIsTicking = false;
        Time.timeScale = 0;

        // display game over UI
        gameOverLogic.ShowGameOverUI();

        SaveHighScoreIfApplicable();
    }

    private void SaveHighScoreIfApplicable()
    {
        float ratio = SettingsManager.currentSettings.ratio;

        int secondsPast = timeManager.secondsPast;
        int score = scoreManager.score;
        Debug.Log("Score: " + score);
        Debug.Log("time: " + secondsPast
            );

        float newRatio = (float)score / (float)secondsPast;

        Debug.Log("old ratio: " + ratio);
        Debug.Log("new ratio: " + newRatio);

        if (newRatio > ratio)

        {
            Debug.Log("is bigger");
            SettingsManager.SaveHighScore(score, secondsPast);
            ShowHighScoreUI(score, secondsPast);
        }else
        {
            HideHighScoreUI();
        }
    }

    private void HideHighScoreUI()
    {
        highScoreUI.SetActive(false);
    }

    private void ShowHighScoreUI(int score, int time)
    {
        // display
        highScoreUI.SetActive(true);
        highScoreUI.GetComponent<TextMeshProUGUI>().text = "New Highscore:\nscore:" + score + " in \ntime:" + time;
    }

    public void CreateNewSpecialEffect()
    {
        if (isEffectSlotFree && !duringEffect)
        {
            availableSpecialEffect = specialEffectFactory.CreateRandomEffect();
            effectRenderer.sprite = specialEffectFactory.effectImage;
            isEffectSlotFree = false;

            StartCoroutine(EffectFade());
        }
    }

    IEnumerator EffectFade()
    {
        yield return new WaitForSecondsRealtime(effectFade);

        isEffectSlotFree = true;
        availableSpecialEffect = null;
        effectRenderer.sprite = null;

    }


    public void LevelUp()
    {
        Debug.Log("Level up");

        enemySpawnManager.CancelInvoke();

        enemySpawnManager.spawnIntervall /= levelUpSpawnIntervallDivider;

        enemyMoveSpeed *= enemyMoveSpeedMultiplier;

        enemySpawnManager.StartSpawn(enemySpawnManager.spawnIntervall, enemyMoveSpeed);
    }

    public void IncreaseScoreByOne()
    {
        scoreManager.IncreaseScoreByOne();
    }

    public void HalfEnemySpeed(int cooldown)
    {
        DisableEffectPossibility();

        StartCoroutine(HalfEnemySpeedCo(cooldown));
    }

    public void HalfClockTime(int cooldown)
    {
        DisableEffectPossibility();

        StartCoroutine(HalfClockTimeCo(cooldown));

    }

    public void ActivateRainbow(int cooldown)
    {
        DisableEffectPossibility();

        StartCoroutine(ActivateRainbowCo(cooldown));
        // add some visual effects, maybe a rainbow color shader
        foreach(GameObject wheelBubble in colorWheel.wheelBubbles)
        {
            wheelBubble.GetComponent<SpriteRenderer>().color = Color.white;
        }

    }

    public void ActivateDestroy()
    {
        DisableEffectPossibility();

        // do someting
        Collider2D[] collided = Physics2D.OverlapCircleAll(Vector2.zero, destroyEffectRange);

        // start a particle system 

        foreach(Collider2D col in collided)
        {
            if (col.gameObject.CompareTag("Enemy"))
            {
                Destroy(col.gameObject);
            }
        }


        isEffectSlotFree = true;
        duringEffect = false;
    }

    private void DisableEffectPossibility()
    {
        duringEffect = true;
        availableSpecialEffect = null;
        effectRenderer.sprite = null;
    }


    IEnumerator ActivateRainbowCo(int cooldown)
    {

        isRainbowEffectActivated = true;

        yield return new WaitForSecondsRealtime(cooldown);

        isRainbowEffectActivated = false;

        isEffectSlotFree = true;
        colorWheel.InitializeColorsOnWheels();
        duringEffect = false;

    }

   

    IEnumerator HalfEnemySpeedCo(int cooldown)
    {
        // get all enemies in scene

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
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
        duringEffect = false;

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
        duringEffect = false;

    }






}
