using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorPuertas : MonoBehaviour
{
    
    public GameObject[] totalPuerta;
    public List<rotarPuerta> rotarPuertas;
    // Start is called before the first frame update
    void Start()
    {
        totalPuerta = GameObject.FindGameObjectsWithTag("Puertas");
        for (int i = 0; i < totalPuerta.Length; i++)
        {
            rotarPuertas.Add(totalPuerta[i].GetComponent<rotarPuerta>());
        }
        //rotarPuertas[0].velocito = .001f;
        //rotarPuertas[1].velocito = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
