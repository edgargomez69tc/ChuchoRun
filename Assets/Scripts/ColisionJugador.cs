using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class ColisionJugador : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemigo")
        {
            vidaJugador.vida--;
            vidaJugador.vida = Mathf.Max(vidaJugador.vida, 0);
            AudioManager.instance.Play("Impacto");
            if (vidaJugador.vida <= 0)
            {
                PlayerManager.isGameOver = true;
                AudioManager.instance.Play("Muerte");
                gameObject.SetActive(false);
            }
            else
            {
                StartCoroutine(RecibirDaño());
            }
           
            
        }
        IEnumerator RecibirDaño()
        {
            Physics2D.IgnoreLayerCollision(6, 8);
            GetComponent<Animator>().SetLayerWeight(1, 1);
            yield return new WaitForSeconds(3);
            GetComponent<Animator>().SetLayerWeight(1, 0);
            Physics2D.IgnoreLayerCollision(6, 8, false);
        }
        
    }
}