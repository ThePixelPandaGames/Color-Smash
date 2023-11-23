using TMPro;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    public TextMeshProUGUI scoreValue;
    public TextMeshProUGUI timeValue;
    public TextMeshProUGUI totalValue;

    public GameObject successfullMesage;


    // Start is called before the first frame update
    void Start()
    {
        UpdateHighScoreUI();
    }

    private void UpdateHighScoreUI()
    {
        scoreValue.text = SettingsManager.currentSettings.score.ToString();
        timeValue.text = SettingsManager.currentSettings.time.ToString();
        totalValue.text = SettingsManager.currentSettings.ratio.ToString();
    }


    public void DeleteHighScore()
    {
        SettingsManager.DeleteHighScore();

        UpdateHighScoreUI();

        successfullMesage.gameObject.SetActive(true);
    }

}
