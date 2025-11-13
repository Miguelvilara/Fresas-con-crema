using UnityEngine;
using UnityEngine.SceneManagement;

public class Victoria : MonoBehaviour
{
    public string menuSceneName = "Menu2";
    public string gameSceneName = "Nivel2";
    private string nombreEscena2 = "Nivel2";
    private string nombreEscena3 = "Nivel3";

    public void Nivel2()
    {
        string ultimoNivel = PlayerPrefs.GetString("UltimoNivel", "");
        if (ultimoNivel.Contains("Nivel1"))
        {
            //Esto quiere decir que el jugador viene del nivel 1 y por tanto hay que llevarlo al nivel 2. 
            SceneManager.LoadScene(nombreEscena2);
        }

        if (ultimoNivel.Contains("Nivel2"))
        {
            SceneManager.LoadScene(nombreEscena3);

        }
       
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}

