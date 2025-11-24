using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverJugador : MonoBehaviour
{
    PlayerControls controls;
    float direccion = 0f;

    public Rigidbody2D PlayerRB;
    public Animator animator;
    public LayerMask sueloLayer;

    public float velocidadMovimiento = 450f;
    public float fuerzaSalto = 8f;

    public bool facingRight = true;
    bool estaPisando;

    public Transform DetectorSuelo;

    private void Awake()
    {
        controls = new PlayerControls();
    }

    private void OnEnable()
    {
        controls.Enable();

        controls.Tierra.Moverse.performed += OnMove;
        controls.Tierra.Moverse.canceled += OnMove; // Para dejar de moverse

        controls.Tierra.Saltar.performed += OnJump;
    }

    private void OnDisable()
    {
        controls.Tierra.Moverse.performed -= OnMove;
        controls.Tierra.Moverse.canceled -= OnMove;

        controls.Tierra.Saltar.performed -= OnJump;

        controls.Disable();
    }

    private void OnMove(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        direccion = ctx.ReadValue<float>();
    }

    private void OnJump(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        if (estaPisando)
        {
            PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, fuerzaSalto);
            AudioManager.instance.Play("Salto");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        estaPisando = Physics2D.OverlapCircle(DetectorSuelo.position, 0.1f, sueloLayer);
        animator.SetBool("estaPisando", estaPisando);


        PlayerRB.velocity = new Vector2(direccion * velocidadMovimiento * Time.fixedDeltaTime, PlayerRB.velocity.y);
        animator.SetFloat("velocidad", Mathf.Abs(direccion));

        if (facingRight && direccion < 0)
        {
            Flip();
        }
        else if (!facingRight && direccion > 0)
        {
            Flip();
        }
    }

    void Flip()
    {

        facingRight = !facingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
}

  
