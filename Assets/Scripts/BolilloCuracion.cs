using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolilloCuracion : MonoBehaviour
{
    // Start is called before the first frame update
    public int cantidadCuracion = 1; // por si después haces bolillos que curen más

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Evitar curar más de lo permitido
            if (vidaJugador.vida < vidaJugador.vidaMaxima)
            {
                vidaJugador.vida += cantidadCuracion;

                // Evitar sobrepasar la vida máxima
                if (vidaJugador.vida > vidaJugador.vidaMaxima)
                    vidaJugador.vida = vidaJugador.vidaMaxima;

                AudioManager.instance.Play("Curacion"); 
                Destroy(gameObject);
            }
        }
    }
}

