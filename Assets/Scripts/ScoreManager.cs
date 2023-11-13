using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    [HideInInspector] public int score;


    void Start()
    {
        score = 0;
        UpdateScoreUI();
    }

    void Update()
    {
        
    }

    public void IncreaseScoreByOne()
    {
        score++;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }
}
