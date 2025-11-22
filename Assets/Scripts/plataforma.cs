using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforma : MonoBehaviour
{
    public GameObject[] putosDestino;
    private int indice = 0;
    private float velocito = 10;

    // Start is called before the first frame update
    void Start()
    {

        putosDestino = GameObject.FindGameObjectsWithTag("cheakpoint");

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, putosDestino[indice].transform.position) <= .1f)
        {
            indice++;
            if (indice >= putosDestino.Length)
            {
                indice = 0;
            }
        }
        this.transform.position = Vector3.MoveTowards(this.transform.position, putosDestino[indice].transform.position, velocito * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}


/*if (indice == 0)
        {
            indice += 1;
            indice--;
        }
 */