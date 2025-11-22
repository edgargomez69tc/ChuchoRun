using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{

    private Transform jugador;
    private NavMeshAgent agente;
    public GameObject[] puntosVigilancia;
    private int indice = 0;
    private bool persiguiendo = false;
    // Start is called before the first frame update
    void Start()
    {
        puntosVigilancia = GameObject.FindGameObjectsWithTag("Patrullaje");
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        agente = GetComponent<NavMeshAgent>();
        agente.updateRotation = false;
        agente.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (persiguiendo)
        {
            agente.SetDestination(jugador.position);
        }
        else
        {
            //agente.SetDestination(jugador.position);
            Patrulla();
        }
    }

    void Patrulla()
    {
        if (Vector3.Distance(this.transform.position, puntosVigilancia[indice].transform.position) <= 0.6f)
        {
            indice++;
            if (indice >= puntosVigilancia.Length)
            {
                indice = 0;
            }
        }
        agente.SetDestination(puntosVigilancia[indice].transform.position);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Siguiendo");
        if (collision.CompareTag("Player"))
        {
            persiguiendo = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("No Siguiendo");
        if (collision.CompareTag("Player"))
        {
            persiguiendo = false;
        }
    }
}
