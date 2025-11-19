using UnityEngine;
using UnityEngine.SceneManagement;

public class Victoria : MonoBehaviour
{
    public string menuSceneName = "Menu2";
    public string nombreEscena2 = "Nivel2";
    public string nombreEscena3 = "Nivel3";

    public void Continuar()
    {
        // Recuperar el ultimo nivel:
        string ultimoNivel = PlayerPrefs.GetString("UltimoNivel", "");

        if (string.IsNullOrEmpty(ultimoNivel))
        {
            Debug.LogWarning("No hay último nivel guardado. Regresando al menú.");
            SceneManager.LoadScene(menuSceneName);
            return;
        }

        Debug.Log("Último nivel jugado: " + ultimoNivel);

        if (ultimoNivel.Contains("Nivel1"))
        {
            SceneManager.LoadScene(nombreEscena2);
            return;
        }

        if (ultimoNivel.Contains("Nivel2"))
        {
            SceneManager.LoadScene(nombreEscena3);
            return;
        }

        // Si no coincide con nada
        Debug.LogWarning("Nivel no reconocido. Enviando al menú.");
        SceneManager.LoadScene(menuSceneName);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}
