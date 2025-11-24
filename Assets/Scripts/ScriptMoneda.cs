using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScriptMoneda : MonoBehaviour
{
    public int valor = 1;
    public static int contarMonedas = 0;
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Solo si el jugador toca la moneda
        if (collision.CompareTag("Player"))
        {
            contarMonedas += valor; // sumar valor
            AudioManager.instance.Play("PanMorido");
            CoinManager.instance.AgregarMoneda(valor);

            Destroy(this.gameObject);
        }
    }
}
