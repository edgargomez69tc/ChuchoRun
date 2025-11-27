using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{

    public int daño = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            VidaBase vidaActual = collision.GetComponentInParent<VidaBase>();

            if (vidaActual != null)
            {
                vidaActual.RecibirDaño(daño);
            }
            
            Destroy(this.gameObject);
        }

    }
}