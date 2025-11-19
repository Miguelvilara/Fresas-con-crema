using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main; 

    [Header("References")]
    [SerializeField] private Tower[] towers;

    [Header("Audio")]
    // Referencias para el clip y el volumen del sonido de colocación
    [SerializeField] private AudioClip placementSoundClip; 
    [SerializeField] private float placementVolume = 1.0f; 

    private int selectedTower = 0;

    private void Awake() {
        main = this; 
    }
    
    // MÉTODO PÚBLICO: Llamado por Plot.cs para reproducir el sonido
    public void PlayPlacementSound(Vector3 position)
    {
        if (placementSoundClip != null)
        {
            // Reproduce el sonido de colocación en la posición de la torre
            AudioSource.PlayClipAtPoint(placementSoundClip, position, placementVolume);
        }
    }

    public Tower GetSelectedTower() {
        return towers[selectedTower];
    }

    public void SetSelectedTower(int _selectedTower){
        selectedTower = _selectedTower;
    }
}