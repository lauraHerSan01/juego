using UnityEngine;

public class CarreraRoad : MonoBehaviour
{
    public float speed = 4f;
    public float resetPosition = -9.278397f;   // límite inferior
    public float startY = 9.278397f;           // dónde reaparece

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Cuando baja lo suficiente, reiniciamos arriba
        if (transform.position.y <= resetPosition)
        {
            transform.position = new Vector3(transform.position.x, startY, transform.position.z);
        }
    }
}
