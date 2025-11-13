using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [Header("Referencias")]
    // Aquí arrastrarás todos los assets de ronda que creaste en el Paso 1.
    [SerializeField] private WaveDefinition[] allWaves; 
    
    // Obtenido de LevelManager.main.startPoint
    private Transform spawnPoint; 

    [Header("Eventos")]
    // Evento estático que los enemigos llamarán al morir.
    public static UnityEvent onEnemyDestroy = new UnityEvent();

    private int currentWaveIndex = 0; // El índice de la ronda actual en el arreglo allWaves
    private int enemiesAlive;
    private bool isSpawning = false;

    private void Awake()
    {
        // El Manager se suscribe a su propio evento para decrementar el contador.
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }

    private void Start()
    {
        // Encontrar el punto de inicio (asumiendo que tu LevelManager ya tiene un startPoint)
        if (LevelManager.main != null && LevelManager.main.startPoint != null)
        {
            // Nota: Usas LevelManager.main.startPoint en tu código original, asumo que es correcto.
            spawnPoint = LevelManager.main.startPoint; 
            // Inicia el proceso de las rondas.
            StartCoroutine(StartWaveSequence()); 
        }
        else
        {
            Debug.LogError("ERROR: LevelManager o startPoint no encontrados. Asegúrate de que LevelManager.main.startPoint exista.");
        }
    }

    private void EnemyDestroyed()
    {
        enemiesAlive--;
    }

    // --- LÓGICA PRINCIPAL DE LAS RONDAS CON CORRUTINAS ---

    // Corrutina principal que gestiona la secuencia de todas las rondas
    private IEnumerator StartWaveSequence()
    {
        // Bucle para recorrer todas las rondas
        while (currentWaveIndex < allWaves.Length)
        {
            WaveDefinition currentWave = allWaves[currentWaveIndex];
            
            Debug.Log($"Iniciando Ronda: {currentWave.waveName}");
            
            // 1. Iniciar la corrutina que genera los enemigos de la ronda
            StartCoroutine(SpawnEnemiesInWave(currentWave));
            isSpawning = true;
            
            // 2. Esperar a que todos los enemigos de la ronda sean generados Y eliminados
            yield return StartCoroutine(WaitForWaveCompletion());

            // 3. La ronda ha terminado, esperamos el tiempo de pausa definido en el asset
            Debug.Log($"Ronda {currentWave.waveName} COMPLETADA. Esperando {currentWave.delayAfterCompletion}s.");
            yield return new WaitForSeconds(currentWave.delayAfterCompletion);

            // 4. Avanzar a la siguiente ronda
            currentWaveIndex++;
        }
        
        Debug.Log("¡TODAS LAS RONDAS COMPLETADAS! VICTORIA.");
    }

    // Corrutina que genera todos los enemigos de una ronda
    private IEnumerator SpawnEnemiesInWave(WaveDefinition wave)
    {
        // Recorrer todos los Grupos de Enemigos definidos en el asset
        foreach (WaveDefinition.EnemyGroup group in wave.enemyGroups)
        {
            // Generar cada enemigo del grupo
            for (int i = 0; i < group.count; i++)
            {
                SpawnEnemy(group.enemyPrefab);
                
                // Esperar la cadencia de aparición definida para este enemigo
                yield return new WaitForSeconds(group.spawnRate);
            }
        }
        
        // Una vez que el bucle termina, YA NO estamos generando enemigos, solo esperando que mueran.
        isSpawning = false; 
        Debug.Log("Generación de enemigos de la ronda terminada.");
    }
    
    // Corrutina para esperar a que los contadores lleguen a cero
    private IEnumerator WaitForWaveCompletion()
    {
        // Esperar mientras AÚN se estén generando enemigos O AÚN haya enemigos vivos
        while (isSpawning || enemiesAlive > 0)
        {
            yield return null; // Espera al siguiente frame
        }
    }


    // Método para instanciar un enemigo
    private void SpawnEnemy(GameObject prefabToSpawn)
    {
        Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);
        enemiesAlive++; // Incrementamos el contador inmediatamente
    }

}
