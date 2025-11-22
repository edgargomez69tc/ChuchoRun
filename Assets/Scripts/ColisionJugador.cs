using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionJugador : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemigo")
        {
            PlayerManager.isGameOver = true;
            gameObject.SetActive(false);
        }
        /*vidaJugador.vida--;
         if(vidaJugador.vida <= 0)
         {
             //vidaJugador.checkPoint = GameObject.FindGameObjectWithTag("checkPoint");
         }
         else
         {
             StartCoroutine(RecibirDaño());
         }
     }

     IEnumerator RecibirDaño()
     {
         Physics2D.IgnoreLayerCollision(6, 8);
         yield return new WaitForSeconds(3);
         Physics2D.IgnoreLayerCollision(6,8, false);
     }
        */
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}