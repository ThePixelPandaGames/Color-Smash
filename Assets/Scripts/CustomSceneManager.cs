using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{

  
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadLeaderboardScene() 
    {
        SceneManager.LoadScene("Leaderboard");
    }

    public void LoadHowToPlayScene()
    {
        SceneManager.LoadScene("How To Play");
    }

    public void LoadSettingsScene()
    {
        SceneManager.LoadScene("Settings");

    }

    public void LoadCreditsScene()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ExitGame()
    {
        Application.Quit();
    }


}
