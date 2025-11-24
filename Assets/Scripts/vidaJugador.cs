using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class vidaJugador : MonoBehaviour
{
    public static int vida = 3;
    public static int vidaMaxima = 3;

    public Image[] bolillos;
    private GameObject checkPoint;
    public Sprite fullBolillo;
    public Sprite emptyBolillo;


    // ---------------------------------------------------------
    // NUEVO: Variables para la invencibilidad
    // ---------------------------------------------------------
    /* public float tiempoInvencibilidad = 1.5f; // Segundos que dura la invencibilidad
     private bool esInvencible = false;        // Interruptor interno
     private SpriteRenderer spriteRend;        // Para cambiar el color del personaje
    */ // ---------------------------------------------------------
    private void Awake()
    {
        vida = vidaMaxima;
    }

    void Start()
    {
        /*if (GameObject.FindGameObjectWithTag("BarraVida") != null)
            barraVida = GameObject.FindGameObjectWithTag("BarraVida").GetComponent<Slider>();*/

        checkPoint = GameObject.FindGameObjectWithTag("checkPoint");

        // NUEVO: Obtenemos el componente visual del personaje
        //spriteRend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        foreach (Image img in bolillos)
        {
            img.sprite = emptyBolillo;
        }

        for (int i = 0; i < vida; i++)
        {
            bolillos[i].sprite = fullBolillo;
        }
        /* if (barraVida != null) barraVida.value = vida;

         if (vida <= 0)
         {
             vida = 100;
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
             Debug.Log("Respawn en checkpoint con vida restaurada");
         }
     }

     // ---------------------------------------------------------
     // NUEVO: FUNCION PERSONALIZADA PARA ADMINISTRAR EL DAÑO
     // (Usaremos esto en lugar de restar vida directamente)
     // ---------------------------------------------------------
     public void RecibirDano(int cantidad)
     {
         // Si el interruptor de invencibilidad está encendido, NO hacemos nada
         if (esInvencible == true)
         {
             return;
         }

         // Si no es invencible, aplicamos el daño
         vida -= cantidad;
         Debug.Log("Jugador recibió daño. Vida restante: " + vida);

         // Activamos la invencibilidad temporalmente
         StartCoroutine(ActivarInvencibilidad());
     }

     // ---------------------------------------------------------
     // NUEVO: RUTINA DE TIEMPO (PARPADEO)
     // ---------------------------------------------------------
     IEnumerator ActivarInvencibilidad()
     {
         esInvencible = true; // Encendemos el escudo

         // VISUAL: Hacemos al personaje semi-transparente (Color rojo opcional)
         // Color(R, G, B, Transparencia) -> 0.5f es 50% transparente
         if (spriteRend != null) spriteRend.color = new Color(1f, 1f, 1f, 0.5f);

         // Esperamos el tiempo configurado
         yield return new WaitForSeconds(tiempoInvencibilidad);

         // VISUAL: Volvemos al color normal (Opaco)
         if (spriteRend != null) spriteRend.color = Color.white;

         esInvencible = false; // Apagamos el escudo
     }

     // ---------------------------------------------------------
     // ZONA DE CHOQUES (Modificada para usar la nueva función)

     // ---------------------------------------------------------
        */
       /* void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemigo"))
            {
                // CAMBIO: En lugar de restar aquí, llamamos a la función
               // RecibirDano(10);
            }
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemigo"))
            {
                // CAMBIO: En lugar de restar aquí, llamamos a la función
               // RecibirDano(10);
            }
        }
       */
    }
}