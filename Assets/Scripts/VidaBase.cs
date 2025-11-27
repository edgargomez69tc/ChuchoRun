using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBase : MonoBehaviour
{
    public int vidaMaxima = 2;
    protected int vidaActual;
   
    protected Animator animator;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        vidaActual = vidaMaxima;
        animator = GetComponent<Animator>();

        if (animator == null)
            animator = GetComponentInChildren<Animator>();
    }

    public virtual void RecibirDaño(int daño)
    {
        vidaActual -= daño;
        if (vidaActual <= 0)
        {
            Morir();
        }
    }
    protected virtual void Morir()
    {
        
        Destroy(gameObject, 1f); // genérico
    }
}
