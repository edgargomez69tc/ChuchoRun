using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    public TextMeshProUGUI mostradorMonedas;
    private int contarMonedas = 0;

    private void Awake()
    {
        // Aseguramos que solo exista un CoinManager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AgregarMoneda(int valor)
    {
        contarMonedas += valor;
        mostradorMonedas.text = contarMonedas.ToString();
        Debug.Log("Total monedas: " + contarMonedas);
    }
}