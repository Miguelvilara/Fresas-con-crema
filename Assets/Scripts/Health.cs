using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int hitPoints = 2;
    [SerializeField] private int currencyWorth = 50;

    [Header("Audio")]
    [SerializeField] private AudioClip deathSoundClip; 
    [SerializeField] private float deathVolume = 1.0f;

    [SerializeField] private AudioClip lifeLostSoundClip; // Nuevo clip para la pérdida de vida
    [SerializeField] private float lifeLostVolume = 1.0f;

    private bool isDestroyed = false;


    public void TakeDamage(int dmg)
{
    hitPoints -= dmg;

    if (hitPoints <= 0 && !isDestroyed)
    {
        isDestroyed = true; // Establecer el estado de destrucción primero

        // 1. Reproducir el Sonido (Debe ser lo primero después del chequeo de estado)
        if (deathSoundClip != null)
        {
            AudioSource.PlayClipAtPoint(deathSoundClip, transform.position, deathVolume);
        }

        // 2. Disparar la Animación
        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetTrigger("Muerte"); // Dispara la animación
        }
        
        // 3. Lógica de Recompensa
        EnemySpawner.onEnemyDestroy.Invoke(); 
        LevelManager.main.IncreaseCurrency(currencyWorth);
        
        // 4. Programar la Destrucción (Espera 1 segundo para que la animación y el sonido terminen)
        Invoke("Destruyeme", 1);
        }
    }

    public void Destruyeme()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Meta")) // Detecta si llegó al final
        {
           if (lifeLostSoundClip != null)
            {
                AudioSource.PlayClipAtPoint(lifeLostSoundClip, transform.position, lifeLostVolume);
            }

            EnemySpawner.onEnemyDestroy.Invoke(); 
            
            LevelManager.main.LoseLife(); // Resta una vida
            Destroy(gameObject);           // Elimina al enemigo
        }
    }

}