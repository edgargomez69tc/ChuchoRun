using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private float velocidad = 15f; // Ajusté un poco la velocidad (85 es muy rápido y puede traspasar paredes)
    public int danio = 1;
    public int direccion = 1;

    void Start()
    {
        Destroy(this.gameObject, 5f); // 5 segundos es suficiente vida útil
    }

    void Update()
    {
        transform.Translate(Vector2.right * direccion * velocidad * Time.deltaTime);
    }

    // Usamos OnTriggerEnter2D si la bala tiene "Is Trigger" marcado.
    // Si desmarcaste "Is Trigger" en la bala, cambia esto a OnCollisionEnter2D
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 1. Si choca con un Enemigo
        if (other.CompareTag("Enemigo"))
        {
            // El daño ya lo calcula el script del enemigo al detectar la bala,
            // así que aquí solo nos preocupamos de destruir la bala.

            Debug.Log("¡Impacto en enemigo!");
            Destroy(this.gameObject); // Se destruye al instante al impactar
        }

        // 2. Si choca con el escenario (Suelo, Paredes, Plataformas)
        // Asegúrate de que tus paredes tengan el Tag "Suelo" o el que uses.
        else if (other.CompareTag("Suelo") || other.CompareTag("Pared"))
        {
            Destroy(this.gameObject);
        }

        // NOTA: Si no es Enemigo ni Suelo (ej. una moneda o checkpoint), 
        // la bala pasará de largo sin destruirse. ¡Eso soluciona tu problema!
    }
}