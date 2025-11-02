using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    
    public string menuSceneName = "Menu2";   
    public string gameSceneName = "Nivel1"; 

    public void RestartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}