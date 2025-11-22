using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaA : MonoBehaviour
{
    private GameObject PuertaB;


    // Start is called before the first frame update
    void Start()
    {
        PuertaB = GameObject.FindGameObjectWithTag("PuertaB");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.transform.position = PuertaB.transform.position;
    }
}
