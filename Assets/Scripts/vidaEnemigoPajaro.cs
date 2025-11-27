using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaEnemigoPajaro : VidaBase
{
    
    protected override void Start()
    {
        base.Start();
    }

    public override void RecibirDaño(int daño)
    {
        AudioManager.instance.Play("Impacto");
        AudioManager.instance.Play("CuervoLastimado");
        base.RecibirDaño(daño);


    }

    protected override void Morir()
    {

        animator.SetBool("EstaMuerto", true);// Aquí puedes agregar animación, partículas, etc.
        AudioManager.instance.Play("MuerteEnemigo");

        // 1. Desactivar TODOS los colliders del enemigo
        Collider2D[] colliders = GetComponentsInChildren<Collider2D>();
        foreach (Collider2D col in colliders)
        {
            col.enabled = false;
        }

        
        this.enabled = false;

        Destroy(gameObject, 0.6f);
    }
}

