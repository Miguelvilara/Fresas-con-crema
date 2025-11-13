using UnityEngine;
using UnityEngine.SceneManagement;

public class Victoria : MonoBehaviour
{
    public string menuSceneName = "Menu2";
    public string gameSceneName = "Nivel2";

    public void Nivel2()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}

