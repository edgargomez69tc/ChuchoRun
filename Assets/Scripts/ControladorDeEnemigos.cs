using UnityEngine;

public class ControladorDeEnemigos : MonoBehaviour
{
    // Arrastra aquí todos tus SpawnPoints (desactivados)
    public GameObject[] spawnPoints;

    // La probabilidad de que CADA uno aparezca
    [Range(0, 1)]
    public float probabilidad = 0.3f; // 30%

    void Start()
    {
        // 1. Este script SÍ se ejecuta, porque está en el objeto padre (que está activo).

        // 2. Revisa cada SpawnPoint que tiene en su lista.
        foreach (GameObject point in spawnPoints)
        {
            // 3. Lanza un dado para CADA uno
            if (Random.value <= probabilidad)
            {
                // 4. Si gana, ¡lo activa!
                point.SetActive(true);
            }
        }
    }
}