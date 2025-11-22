using UnityEngine;

public class RecargarBalas : MonoBehaviour
{
    public int cantidadRecarga = 6; // Cuántas balas da este pickup

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Solo el jugador puede recogerlo
        if (other.CompareTag("Player"))
        {
            // Buscar la pistola del jugador
            Pistola pistola = other.GetComponentInChildren<Pistola>();

            if (pistola != null)
            {
                pistola.contadorBalas += cantidadRecarga;

                // Que no pase el máximo de 12
                pistola.contadorBalas = Mathf.Clamp(pistola.contadorBalas, 0, 12);

                pistola.mostradorBalas.text = pistola.contadorBalas + "/12";
            }

            // Destruir el objeto de recarga
            Destroy(gameObject);
        }
    }
}