using UnityEngine;

public class DecoracionMovimiento : MonoBehaviour
{
    public float speed = 4f; // Igual que tus casas

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;

        if (transform.position.y < -15f)
            Destroy(gameObject);
    }
}
