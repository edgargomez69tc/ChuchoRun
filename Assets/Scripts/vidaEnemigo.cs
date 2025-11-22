using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class vidaEnemigo : MonoBehaviour
{
    /*[Header("Configuración del Enemigo")]
    private int vida = 3;
    public int danoAlJugador = 10; // NUEVO: Cuánto daño le hace este enemigo al tocarte

    [Header("Recompensas")]
    public GameObject monedaPrefab;

    // 1. SI ES TRIGGER (El enemigo es un fantasma o zona)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // A. Lógica de recibir Balazo (LO QUE YA TENÍAS)
        Bala bala = collision.GetComponent<Bala>();
        if (bala != null)
        {
            ProcesarDaño(bala);
        }

        // B. Lógica de chocar con Jugador (NUEVO)
        if (collision.CompareTag("Player")) // Asegúrate que tu personaje tenga el Tag "Player"
        {
            // Buscamos el script 'vidaJugador' en el objeto con el que chocamos
            vidaJugador salud = collision.GetComponent<vidaJugador>();

            if (salud != null)
            {
               // salud.RecibirDano(danoAlJugador); // Usamos la función que creamos en el paso anterior
            }
        }
    }

    // 2. SI ES COLLISION (El enemigo es sólido y rebotas)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // A. Lógica de recibir Balazo (LO QUE YA TENÍAS)
        Bala bala = collision.gameObject.GetComponent<Bala>();
        if (bala != null)
        {
            ProcesarDaño(bala);
        }

        // B. Lógica de chocar con Jugador (NUEVO)
        if (collision.gameObject.CompareTag("Player"))
        {
            vidaJugador salud = collision.gameObject.GetComponent<vidaJugador>();

            if (salud != null)
            {
                //salud.RecibirDano(danoAlJugador);
            }
        }
    }

    // 3. LÓGICA DE MORIR (Igual que antes)
    private void ProcesarDaño(Bala bala)
    {
        vida -= bala.danio;

        // Opcional: destruir la bala
        // Destroy(bala.gameObject); 

        if (vida <= 0)
        {
            if (monedaPrefab != null)
            {
                Instantiate(monedaPrefab, transform.position, Quaternion.identity);
            }

            Destroy(this.gameObject, 0.1f);
        }
    }
    */
}
    