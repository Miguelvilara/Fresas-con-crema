using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int hitPoints = 2;
    [SerializeField] private int currencyWorth = 50;

    private bool isDestroyed = false;


    public void TakeDamage(int dmg)
    {
        hitPoints -= dmg;

        if (hitPoints <= 0 && !isDestroyed)
        {
            EnemySpawner.onEnemyDestroy.Invoke();
            LevelManager.main.IncreaseCurrency(currencyWorth);
            isDestroyed = true;
            //Animacion
            Animator animator = GetComponent<Animator>();
            if (animator != null)
            {
                //Aqui usa la animacion
                animator.SetTrigger("Muerte"); //La animacion de muerte se ejecutara con el trigger de muerte.

            }
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
        LevelManager.main.LoseLife(); // Resta una vida
        Destroy(gameObject);          // Elimina al enemigo
    }
   }

}