using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pistola : MonoBehaviour
{
    public GameObject bala;

    private float contadorTiempo = 0;
    public float tiempoEntreTiro = 0.25f;
    private MoverJugador jugador; // referencia al script del jugador
    public TextMeshProUGUI mostradorBalas;
    public int contadorBalas = 12;

    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<MoverJugador>();
    }

    // Update is called once per frame
    void Update()
    {

        if (contadorTiempo < tiempoEntreTiro)
        {
            contadorTiempo += Time.deltaTime;
        }

        /*if (Input.GetButton("Fire1") && (contadorTiempo >= tiempoEntreTiro) && contadorBalas > 0)
        {
            GameObject nuevaBala = Instantiate(bala, this.transform.position, Quaternion.identity);

            // Le pasamos la dirección actual del jugador
            //nuevaBala.GetComponent<Bala>().direccion = jugador.direccion;

            contadorTiempo = 0;
            contadorBalas--;
            mostradorBalas.text = contadorBalas + "/12";

        }
        */

        if (Input.GetKeyDown(KeyCode.R))
        {
            contadorBalas = 12;
            mostradorBalas.text = contadorBalas + "/12";

        }

    }
}
