using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    public Transform startPoint;
    public Transform[] path;

    public int currency;

    [Header("UI")]
    public TextMeshProUGUI livesText;

    [Header("Vidas del jugador")]
    public int maxLives = 10;
    private int currentLives; 

    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        currency = 100;
        currentLives = maxLives;

        UpdateLivesUI();
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

        UpdateLivesUI();

        if (currentLives <= 0)
        {
            GameOver();
        }
    }

    private void UpdateLivesUI(){

        if (livesText != null)
        {
            livesText.text = "Lifes: " + currentLives.ToString();

        }
    }

    private void GameOver()
    {
        Debug.Log("GAME OVER");
        Time.timeScale = 1f; 
        SceneManager.LoadScene("GameOverScene");
    }
}
