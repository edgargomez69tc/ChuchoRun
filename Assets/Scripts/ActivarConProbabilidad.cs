using UnityEngine;

public class ActivarConProbabilidad : MonoBehaviour
{
    // Puedes ajustar esto en el Inspector para cada SpawnPoint
    [Range(0, 1)] // Slider de 0% a 100%
    public float probabilidadDeAparecer = 0.3f; // 30% por defecto

    void Start()
    {
        // Lanza un "dado" virtual
        if (Random.value <= probabilidadDeAparecer)
        {
            // Si ganas, activa este objeto (el SpawnPoint)
            gameObject.SetActive(true);
        }

        // Si pierdes (el "else"), no hace nada.
        // El SpawnPoint (y su enemigo hijo) se quedan desactivados.
    }
}