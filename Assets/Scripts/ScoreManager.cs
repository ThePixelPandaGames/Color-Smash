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


    public void IncreaseScoreByOne()
    {
        score++;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "" + score;
    }
}
