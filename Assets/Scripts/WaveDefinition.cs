using UnityEngine;

// Permite crear nuevos assets de ronda desde el menú de Unity
[CreateAssetMenu(fileName = "NewWave", menuName = "Wave/Wave Definition")]
public class WaveDefinition : ScriptableObject
{
    // Una clase interna para agrupar tipos de enemigos dentro de la ronda
    [System.Serializable]
    public class EnemyGroup
    {
        [Tooltip("El Prefab del enemigo a generar.")]
        public GameObject enemyPrefab; 
        
        [Tooltip("La cantidad de este enemigo en el grupo.")]
        public int count;              
        
        [Tooltip("Tiempo de espera entre la aparición de cada enemigo de este grupo.")]
        public float spawnRate;        
    }

    [Header("Configuración de la Ronda")]
    [Tooltip("El nombre que aparecerá en pantalla al inicio de la ronda.")]
    public string waveName = "Ronda 1"; 

    [Tooltip("Lista de los diferentes grupos de enemigos que aparecerán en esta ronda.")]
    public EnemyGroup[] enemyGroups; 
    
    [Tooltip("Tiempo de pausa después de que esta ronda ha terminado y antes de que inicie la siguiente.")]
    public float delayAfterCompletion = 5f; 
}