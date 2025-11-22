// Importamos las librerías necesarias
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("CONFIGURACIÓN DE PREFABS")]
    // Arrastra aquí tus prefabs de enemigos desde la ventana de Proyecto
    public GameObject[] enemyPrefabs;

    [Header("PUNTO DE GENERACIÓN")]
    // Un objeto vacío que marca dónde deben aparecer los enemigos (fuera de pantalla, a la derecha)
    public Transform spawnPoint;

    [Header("TIEMPOS DE GENERACIÓN (Segundos)")]
    // El tiempo mínimo y máximo de espera entre enemigos
    public float minSpawnTime = 1.5f;
    public float maxSpawnTime = 3.5f;

    [Header("POSICIÓN Y ALEATORIA (Offset)")]
    // El rango vertical donde pueden aparecer
    // Si tu spawnPoint está en Y=0, un offset de -1 a 1 hará que aparezcan entre Y=-1 y Y=1
    public float minYOffset = -1.0f;
    public float maxYOffset = 2.0f;

    [Header("DIFICULTAD (Opcional)")]
    // Cada cuántos segundos el juego se vuelve más difícil
    public float timeToIncreaseDifficulty = 10.0f;
    // Cuánto se reduce el tiempo de espera
    public float timeDecreaseAmount = 0.1f;
    // El tiempo de espera más rápido posible (para que no sea imposible)
    public float minPossibleSpawnTime = 0.7f;


    // --- Métodos de Unity ---

    void Start()
    {
        // Inicia la "Corrutina" que generará enemigos sin parar
        StartCoroutine(SpawnEnemiesLoop());

        // Inicia la "Corrutina" opcional para aumentar la dificultad
        StartCoroutine(IncreaseDifficultyLoop());
    }


    // --- Corrutinas ---

    /// <summary>
    /// Bucle principal que genera enemigos.
    /// </summary>
    private IEnumerator SpawnEnemiesLoop()
    {
        // Este bucle se ejecutará "para siempre" mientras el objeto esté activo
        while (true)
        {
            // 1. Esperar un tiempo aleatorio
            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);

            // 2. Seleccionar un prefab de enemigo aleatorio
            int index = Random.Range(0, enemyPrefabs.Length);
            GameObject enemyToSpawn = enemyPrefabs[index];

            // 3. Calcular la posición Y aleatoria
            float randomY = Random.Range(minYOffset, maxYOffset);

            // Usamos la posición del spawnPoint y le sumamos el offset en Y
            Vector3 spawnPosition = new Vector3(
                spawnPoint.position.x,
                spawnPoint.position.y + randomY,
                spawnPoint.position.z
            );

            // 4. Crear (Instanciar) el enemigo
            Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);
        }
    }


    /// <summary>
    /// Bucle opcional que aumenta la dificultad con el tiempo.
    /// </summary>
    private IEnumerator IncreaseDifficultyLoop()
    {
        while (true)
        {
            // Espera el tiempo definido (ej. 10 segundos)
            yield return new WaitForSeconds(timeToIncreaseDifficulty);

            // Reduce los tiempos de espera
            // Usamos Mathf.Max para asegurarnos de que nunca bajen del mínimo posible
            maxSpawnTime = Mathf.Max(minPossibleSpawnTime + 0.1f, maxSpawnTime - timeDecreaseAmount);
            minSpawnTime = Mathf.Max(minPossibleSpawnTime, minSpawnTime - timeDecreaseAmount);
        }
    }
}
