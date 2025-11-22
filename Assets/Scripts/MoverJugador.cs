using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverJugador : MonoBehaviour
{
    public float velocidad = 1;
    private float x;
    private Rigidbody2D rb;
    public float velocidadBase;
    public float fuerzaSalto = 1;
    private bool quiereSaltar = false;
    public LayerMask capaSuelo;
    public Transform detectorSuelos;
    private float radioDetectorSuelos = 0.1f;
    private bool tocandoSuelo = false;
    public int direccion = 1; // 1 derecha, -1 izquierda


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocidadBase = velocidad; // inicializamos la base
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");


        //salto
        quiereSaltar = Input.GetButton("Jump");

        //Debug.Log("aqui Update");

        //detectar Suelo
        tocandoSuelo = Physics2D.OverlapCircle(detectorSuelos.position,
            radioDetectorSuelos, capaSuelo);

        if (x > 0)
        {
            direccion = 1; // mirando a la derecha
            transform.localScale = new Vector3(1, 1, 1); // escala normal
        }
        else if (x < 0)
        {
            direccion = -1; // mirando a la izquierda
            transform.localScale = new Vector3(-1, 1, 1); // invertimos en X
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Box")
        {
            FindObjectOfType<GroundSpawner>().SpawnTile();
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(x * velocidad, rb.velocity.y);


        //salto
        if (quiereSaltar && tocandoSuelo)
        {
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }

    public void ModificarVelocidad(float multiplicador)
    {
        velocidad = velocidadBase * multiplicador;
    }



}
