using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class vidaEnemigo : MonoBehaviour
{
    public int vidaMaxima = 2;
    private int vidaActual;
    public Animator animator;
    bool EstaMuerto;
    private void Start()
    {
        vidaActual = vidaMaxima;
    }

    public void RecibirDaño(int daño)
    {
        vidaActual -= daño;
        AudioManager.instance.Play("LomoLastimado");

        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    private void Morir()
    {
        
        animator.SetBool("EstaMuerto", true);// Aquí puedes agregar animación, partículas, etc.
        AudioManager.instance.Play("MuerteEnemigo");

        // 1. Desactivar TODOS los colliders del enemigo
        Collider2D[] colliders = GetComponents<Collider2D>();
        foreach (Collider2D col in colliders)
        {
            col.enabled = false;
        }

        // 2. Detener su movimiento si tiene Rigidbody
        /*Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
        }*/

        // 3. Evitar que vuelva a recibir daño
        this.enabled = false;

        Destroy(gameObject, 0.8f);
    }
}
    