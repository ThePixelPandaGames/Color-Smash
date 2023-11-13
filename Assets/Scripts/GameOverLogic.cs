using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverLogic : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject colorWheel;
    public GameObject effectImage;
    public void ShowGameOverUI()
    {
        gameOverUI.SetActive(true);
        colorWheel.SetActive(false);
        effectImage.SetActive(false);
    }

    public void HideGameOverUI()
    {
        gameOverUI.SetActive(false);
        colorWheel.SetActive(true);
        effectImage.SetActive(true);
    }

    public void TryAgainButton()
    {
        HideGameOverUI();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenuButton()
    {
        // use scene manager to go back
    }
}
