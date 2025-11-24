using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerShoot : MonoBehaviour
{
    // Start is called before the first frame update
   PlayerControls controls;
    public Animator animator;

    public GameObject Bala;
    public Transform Pistola;
    public float fuerzaDisparo = 1500f;

    public int maxBalas = 12;          // Capacidad del cargador
    public int balasActuales;         // Las balas que tienes ahora
    public TextMeshProUGUI textoBalas; // Referencia al texto UI
    private void Awake()
    {
        controls = new PlayerControls();
        balasActuales = maxBalas;
        
    }
    private void OnEnable()
    {
        controls.Enable();
        controls.Tierra.Lanzar.performed += OnShoot;
        controls.Tierra.Recargar.performed += OnReload;
    }

    private void OnDisable()
    {
        controls.Tierra.Lanzar.performed -= OnShoot;
        controls.Tierra.Recargar.performed -= OnReload;
        controls.Disable();
    }

    private void Update()
    {
        textoBalas.text = balasActuales + " / " + maxBalas;
    }

    private void OnShoot(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        Shoot();
    }
    private void Shoot()
    {
        if (balasActuales <= 0)
        {
            balasActuales = 0; // asegurar que nunca sea negativo
            
            return;
        }
        balasActuales--;
        animator.SetTrigger("lanzar");
        AudioManager.instance.Play("Lanzamiento");
        GameObject go = Instantiate(Bala, Pistola.position, Bala.transform.rotation);
        if(GetComponent<MoverJugador>().facingRight)
        {
            go.GetComponent<Rigidbody2D>().AddForce(Vector2.right * fuerzaDisparo);
        }
        else
        {
            go.GetComponent<Rigidbody2D>().AddForce(Vector2.left * fuerzaDisparo);
        }
        Destroy(go, 1.5f);
    }

    private void OnReload(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        Reload();
    }

    private void Reload()
    {
        AudioManager.instance.Play("Recargar");
        if (balasActuales == maxBalas)
            return;

        balasActuales = maxBalas;
    }

    public void Recargar(int cantidad)
    {
        balasActuales += cantidad;

        // Evitar pasar el máximo
        if (balasActuales > maxBalas)
            balasActuales = maxBalas;

        // Actualizar UI
        textoBalas.text = balasActuales.ToString();
    }

}
