using UnityEngine;
using UnityEngine.SceneManagement; // Para reiniciar el nivel si quieres

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    public Transform startPoint;
    public Transform[] path;

    public int currency;

    [Header("Vidas del jugador")]
    public int maxLives = 10;   // Vidas iniciales
    private int currentLives;   // Vidas actuales

    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        currency = 100;
        currentLives = maxLives; // Inicializa las vidas
    }

    // Sistema de dinero
    public void IncreaseCurrency(int amount)
    {
        currency += amount;
    }

    public bool SpendCurrency(int amount)
    {
        if (amount <= currency)
        {
            currency -= amount;
            return true;
        }
        else
        {
            Debug.Log("No hay lana bro");
            return false;
        }
    }

    // Sistema de vidas
    public void LoseLife(int amount = 1)
    {
        currentLives -= amount;
        Debug.Log("Vidas restantes: " + currentLives);

        if (currentLives <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("GAME OVER");
        Time.timeScale = 0f; // Pausa el juego
        // Aquí podrías agregar una pantalla de Game Over más adelante
    }
}
