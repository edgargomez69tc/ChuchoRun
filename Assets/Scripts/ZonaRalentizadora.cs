using UnityEngine;
using System.Collections;

public class ZonaRalentizadora : MonoBehaviour
{
    [Tooltip("Multiplicador de velocidad (ejemplo: 0.5 = mitad de velocidad)")]
    [Range(0f, 1f)]
    public float factorRalentizacion = 0.5f;

    [Tooltip("Duración del efecto en segundos")]
    public float duracion = 3f;

    [Tooltip("Etiqueta del jugador que se verá afectado")]
    public string etiquetaJugador = "Player";

    private bool yaActivado = false; // se aplica solo una vez por objeto

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (yaActivado) return; // ya se usó en este objeto

        if (other.CompareTag(etiquetaJugador))
        {
            MoverJugador jugador = other.GetComponent<MoverJugador>();
            if (jugador != null)
            {
                yaActivado = true; // marcar esta instancia como usada
                StartCoroutine(AplicarRalentizacionTemporal(jugador));
            }
        }
    }*/

   /* private IEnumerator AplicarRalentizacionTemporal(MoverJugador jugador)
    {
        jugador.ModificarVelocidad(factorRalentizacion);
        yield return new WaitForSeconds(duracion);
        jugador.ModificarVelocidad(1f); // restaurar velocidad normal
    }
   */
}
