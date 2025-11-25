using UnityEngine;

public class MoverTramo : MonoBehaviour
{
    public static float velocidadGlobal = 5f;

    public float alturaDeDestruccion = -15f;

    void Update()
    {
        transform.Translate(Vector3.down * velocidadGlobal * Time.deltaTime);

        if (transform.position.y < alturaDeDestruccion)
        {
            Destroy(gameObject);
        }
    }
}