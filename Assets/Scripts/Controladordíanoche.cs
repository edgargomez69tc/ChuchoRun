using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controladordíanoche : MonoBehaviour
{
    // Arrastra tus fondos aquí desde el Inspector
    public GameObject fondoDia;
    public GameObject fondoNoche;

    // Tiempo (en segundos) que durará cada ciclo (día o noche)
    public float tiempoDeCiclo = 60f;

    void Start()
    {
        // 1. Asegurarnos de empezar en un estado conocido (ej. empieza de día)
        fondoDia.SetActive(true);
        fondoNoche.SetActive(false);

        // 2. Iniciar la corrutina que hará el cambio
        StartCoroutine(CicloDiaNoche());
    }

    IEnumerator CicloDiaNoche()
    {
        // 3. Este bucle se repetirá infinitamente
        while (true)
        {
            // --- ESTAMOS DE DÍA ---
            // 4. Esperar el tiempo de ciclo (ej. 60 segundos)
            yield return new WaitForSeconds(tiempoDeCiclo);

            // 5. Cambiar a noche
            Debug.Log("Cambiando a Noche");
            fondoDia.SetActive(false);
            fondoNoche.SetActive(true);

            // --- ESTAMOS DE NOCHE ---
            // 6. Esperar el mismo tiempo
            yield return new WaitForSeconds(tiempoDeCiclo);

            // 7. Cambiar de vuelta a día
            Debug.Log("Cambiando a Día");
            fondoDia.SetActive(true);
            fondoNoche.SetActive(false);

            // El bucle 'while(true)' hace que vuelva al paso 4
        }
    }
}