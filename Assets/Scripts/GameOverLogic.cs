using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverLogic : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject colorWheel;
    public GameObject effectImage;
    public GameObject centerBubble;
    public void ShowGameOverUI()
    {
        gameOverUI.SetActive(true);
        colorWheel.SetActive(false);
        effectImage.SetActive(false);
        centerBubble.SetActive(false);

    }

    public void HideGameOverUI()
    {
        gameOverUI.SetActive(false);
        colorWheel.SetActive(true);
        effectImage.SetActive(true);
        centerBubble.SetActive(true);
    }

    public void TryAgainButton()
    {
        MusicManager musicManager = GameObject.FindGameObjectWithTag("Music Manager").GetComponent<MusicManager>();
        musicManager.StartMenuMusic();
        HideGameOverUI();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenuButton()
    {
        MusicManager musicManager = GameObject.FindGameObjectWithTag("Music Manager").GetComponent<MusicManager>();
        musicManager.StartMenuMusic();
        HideGameOverUI();
        SceneManager.LoadScene("Main Menu");
    }
}
