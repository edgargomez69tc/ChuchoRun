using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    private GameObject objetivo;
    public float minX = 0, minY = 0, maxX = 0, maxY=0;
    public float velocidad = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        objetivo = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position = objetivo.transform.position + new Vector3(0, 0, -10);

        /*this.transform.position = new Vector3(
            Mathf.Clamp(objetivo.transform.position.x, minX, maxX),
            Mathf.Clamp(objetivo.transform.position.y, minY, maxY), -10);*/

        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(
            Mathf.Clamp(objetivo.transform.position.x, minX, maxX),
            Mathf.Clamp(objetivo.transform.position.y, minY, maxY),
            -10),
            velocidad);
    }
}
