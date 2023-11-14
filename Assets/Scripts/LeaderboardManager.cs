using TMPro;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    public TextMeshProUGUI scoreValue;
    public TextMeshProUGUI timeValue;
    public TextMeshProUGUI totalValue;

    // Start is called before the first frame update
    void Start()
    {
        Settings current = SettingsManager.currentSettings;

        scoreValue.text = current.score.ToString();
        timeValue.text = current.time.ToString();
        totalValue.text = current.ratio.ToString(); 
    }

}
