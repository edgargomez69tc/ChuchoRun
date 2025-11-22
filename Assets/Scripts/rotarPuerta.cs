using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotarPuerta : MonoBehaviour
{
    private Transform puerta;
    private Quaternion cerraa;
    private Quaternion abierta;
    private Quaternion rotacion;

    public float velocito = 1;


    // Start is called before the first frame update
    void Start()
    {
        puerta = this.transform.GetChild(0);
        cerraa = Quaternion.Euler(0, 0, 0);
        abierta = Quaternion.Euler(0, 0, 90);
        rotacion = cerraa;
        puerta.localRotation = rotacion;
    }

    // Update is called once per frame
    void Update()
    {
        puerta.localRotation = Quaternion.Lerp(puerta.localRotation, rotacion, velocito);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rotacion = abierta;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rotacion = cerraa;
        }
    }
}
