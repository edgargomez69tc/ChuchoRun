using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaRomper : MonoBehaviour
{
    private Vector3 posInicial;
    private Vector3 posDestino;
    // Start is called before the first frame update
    void Start()
    {
        posInicial = this.transform.GetChild(0).transform.localPosition; // this.transform.localPosition;
        posDestino = posInicial + new Vector3(0, 2.1f, 0);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            this.transform.GetChild(0).localPosition = posDestino;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            this.transform.GetChild(0).localPosition = posInicial;

        }
    }
}
