using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    private GameObject PuertaA;


    // Start is called before the first frame update
    void Start()
    {
        PuertaA = GameObject.FindGameObjectWithTag("PuertaA");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.transform.position = PuertaA.transform.position;
    }
}