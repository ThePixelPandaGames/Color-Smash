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
        totalValue.text = SettingsManager.currentSettings.ratio.ToString().Substring(0, 5);
    }


    public void DeleteHighScore()
    {
        SettingsManager.DeleteHighScore();

        scoreValue.text = "0";
        timeValue.text = "0";
        totalValue.text = "0";

        successfullMesage.gameObject.SetActive(true);
    }

}
