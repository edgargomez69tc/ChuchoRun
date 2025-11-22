using System.Collections;

using UnityEngine;



public class GroundSpawner : MonoBehaviour

{

    public GameObject groundPrefab;

    private Vector3 nextTileSpawnPos;

    // La variable para saber cuándo generar

    public float tileWidth = 40f;



    // Start is called before the first frame update

    void Start()

    {

        // Posición inicial del primer bloque (ajústala a tu escena)

        nextTileSpawnPos = new Vector3(-19.01f, -5.97f, 0.1420f);



        // Generamos el primer bloque y unos cuantos más al inicio (ejemplo)

        for (int i = 0; i < 5; i++)

        {

            SpawnTile();

        }

    }



    // El método de generación ahora es privado (no es un ciclo)

    public void SpawnTile()

    {

        GameObject temp = Instantiate(groundPrefab, nextTileSpawnPos, Quaternion.identity);



        // **IMPORTANTE:** Aquí está la lógica de la posición.

        // Asumo que el punto de conexión está en el GetChild(1) de tu Prefab.

        // Si no, la forma más fácil es sumarle el ancho del tile.



        // **OPCIÓN 1: Usando tu lógica original (si tu prefab tiene un punto de conexión)**

        nextTileSpawnPos = temp.GetComponent<Transform>().GetChild(1).transform.position;



        // **OPCIÓN 2: La forma más común para endless runners**

        // Si no usas un punto de conexión, simplemente avanza la posición X 

        // por el ancho de tu prefab (debes medirlo).

        // nextTileSpawnPos.x += tileWidth; 



        // Si estás haciendo un runner, la posición Y debe variar para crear saltos

        // nextTileSpawnPos.y += Random.Range(-1f, 1f); 

    }



    // **NUEVO:** Usamos el Update() para llamar a SpawnTile() cuando sea necesario.

    void Update()

    {

        // Condición de Generación:

        // Verifica si la posición donde debería generarse el siguiente bloque 

        // ya ha entrado en la vista de la cámara o está cerca.



        // Por simplicidad, aquí lo haremos por distancia al jugador.

        // **Reemplaza 'Player' con una referencia real a tu jugador.**

        GameObject player = GameObject.FindGameObjectWithTag("Player");



        if (player != null && nextTileSpawnPos.x < player.transform.position.x + 30f)

        {

            SpawnTile();

        }

    }

}