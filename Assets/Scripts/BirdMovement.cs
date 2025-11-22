using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public float speed = 5f; // Velocidad del pájaro
    private float destroyX = -15f; // Posición X donde se borrará (ajusta según tu cámara)

    void Update()
    {
        // Mueve el pájaro hacia la izquierda cada frame
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Destruye el objeto si sale de la pantalla por la izquierda
        // para no llenar la memoria de pájaros infinitos.
        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}